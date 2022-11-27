using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
#endif
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    public class FishController : MonoBehaviour
    {
        public Vector3 initialPosition, targetPosition;
        public float elapsed;
        public bool destroyOnDone;
        public void SetTarget(Vector3 newTargetPosition, bool newDestroyOnDone)
        {
            elapsed = 0;
            initialPosition = transform.position;
            targetPosition = newTargetPosition;
            destroyOnDone = newDestroyOnDone;
            transform.rotation = Quaternion.LookRotation(targetPosition - initialPosition);
        }

        public bool OnPlace()
        {
            return Vector3.Distance(transform.position, targetPosition) < 0.01f;
        }

        void Update()
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsed);
            elapsed += Time.deltaTime;
            if (destroyOnDone && OnPlace())
            {
                Destroy(gameObject);
            }
        }
    }

    public Transform spawnPoint, demoPoint, destroyPoint;
    public GameObject notEnoughtMoneyPanel, nextButton, prevButton;
    AudioSource audioSource;
    public AudioClip swipeFish;
    public AudioClip closeButtonClip;
    public AudioClip dontEnoughMoneyClip;
    public AudioClip buyClip;
    public AudioClip selectClip;
    public SplashScreenController splashScreen;

    public int selectedFishIndex = 0, activeFishIndex = 0;
    public int playerBonus = 0;

    public GameObject[] fishes;
    public FishStatisticController[] fishStatistics;
    public bool[] fishAvailable;
    public FishController activeFish = null;

    public float maxSpeed = 0.0f;
    public int maxHealth = 0;
    public float maxHealthRegenerationTime = 0.0f;
    public float maxSlowModeRegenerationTime = 0.0f;
    void UpdateMetrics()
    {
        activeFishIndex = Utils.GetActiveFishIndex();
        selectedFishIndex = activeFishIndex;
        playerBonus = Utils.GetBonus();

        fishStatistics = new FishStatisticController[fishes.Length];
        fishAvailable = new bool[fishes.Length];
        for (int i = 0; i < fishes.Length; ++i)
        {
            fishStatistics[i] = fishes[i].GetComponent<FishStatisticController>();
            maxSpeed = Mathf.Max(maxSpeed, fishStatistics[i].moveSpeed);
            maxHealth = Mathf.Max(maxHealth, fishStatistics[i].maxHealth);
            if (fishStatistics[i].canHealthRegenerate)
            {
                maxHealthRegenerationTime = Mathf.Max(maxHealthRegenerationTime, fishStatistics[i].healthRegenerationTime);
            }
            if (fishStatistics[i].canSlowMode)
            {
                maxSlowModeRegenerationTime = Mathf.Max(maxSlowModeRegenerationTime, fishStatistics[i].slowModeRegenerationTime);
            }

            fishAvailable[i] = Utils.IsAvailableFish(i);
        }
        maxHealthRegenerationTime *= 1.1f;
        maxSlowModeRegenerationTime *= 1.1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateMetrics();
        UpdateActiveFish();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateActiveFish()
    {
        if (activeFish)
        {
            activeFish.SetTarget(destroyPoint.position, true);
        }
        activeFish = Instantiate(fishes[selectedFishIndex], spawnPoint.position, Quaternion.identity, transform.parent).AddComponent<FishController>();
        activeFish.SetTarget(demoPoint.position, false);
    }

    public void OnNextFishClick()
    {
        if (!activeFish.OnPlace())
        {
            return;
        }
        audioSource.PlayOneShot(swipeFish);
        selectedFishIndex += 1;
        if (selectedFishIndex >= fishes.Length)
        {
            selectedFishIndex = 0;
        }
        UpdateActiveFish();
    }

    public void OnPrevFishClick()
    {
        if (!activeFish.OnPlace())
        {
            return;
        }
        audioSource.PlayOneShot(swipeFish);
        selectedFishIndex -= 1;
        if (selectedFishIndex < 0)
        {
            selectedFishIndex = fishes.Length - 1;
        }
        UpdateActiveFish();
    }
    public void OnCloseNotEnoughtMoneyClick()
    {
        audioSource.PlayOneShot(closeButtonClip);
        notEnoughtMoneyPanel.SetActive(false);
        nextButton.SetActive(true);
        prevButton.SetActive(true);
    }
    public void ShowNotEnoughtMoney()
    {
        notEnoughtMoneyPanel.SetActive(true);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
    }
    public void OnBuyFishClick()
    {
        if (!fishAvailable[selectedFishIndex])
        {
            int selectedFishCost = fishStatistics[selectedFishIndex].cost;
            if (selectedFishCost > playerBonus)
            {
                audioSource.PlayOneShot(dontEnoughMoneyClip);
                ShowNotEnoughtMoney();
            }
            else
            {
                audioSource.PlayOneShot(buyClip);
                playerBonus -= selectedFishCost;
                Utils.SetBonus(playerBonus);

                fishAvailable[selectedFishIndex] = true;
                Utils.BuyFish(selectedFishIndex);

                #if ENABLE_CLOUD_SERVICES_ANALYTICS
                Analytics.CustomEvent("buyFish", new Dictionary<string, object> {
                    {"index", selectedFishIndex },
                    {"cost", selectedFishCost }
                });
                #endif
            }
        }
    }
    public void OnSelectFishClick()
    {
        if (fishAvailable[selectedFishIndex])
        {
            audioSource.PlayOneShot(selectClip);
            Utils.SetActiveFishIndex(selectedFishIndex);
            activeFishIndex = selectedFishIndex;

            #if ENABLE_CLOUD_SERVICES_ANALYTICS
            Analytics.CustomEvent("selectFish", new Dictionary<string, object> {
                    {"index", selectedFishIndex }
            });
            #endif
        }
    }

    public void OnCloseButtonClick()
    {
        audioSource.PlayOneShot(closeButtonClip);

        splashScreen.LoadScene("MainMenuScene");
    }
}
