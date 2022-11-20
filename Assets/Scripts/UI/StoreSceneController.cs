using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSceneController : MonoBehaviour
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

    public Transform spawnPoint;
    public Transform demoPoint;
    public Transform destroyPoint;

    public int activeFishIndex = 0;
    
    public GameObject[] fishes;
    public FishController activeFish = null;

    public float maxSpeed = 0.0f;
    public int maxHealth = 0;
    public float maxHealthRegenerationTime = 0.0f;
    public float maxSlowModeRegenerationTime = 0.0f;
    void UpdateMetrics()
    {
        foreach (GameObject fish in fishes)
        {
            FishStatisticController fishStatistic = fish.GetComponent<FishStatisticController>();
            maxSpeed = Mathf.Max(maxSpeed, fishStatistic.moveSpeed);
            maxHealth = Mathf.Max(maxHealth, fishStatistic.maxHealth);
            if (fishStatistic.canHealthRegenerate)
            {
                maxHealthRegenerationTime = Mathf.Max(maxHealthRegenerationTime, fishStatistic.healthRegenerationTime);
            }
            if (fishStatistic.canSlowMode)
            {
                maxSlowModeRegenerationTime = Mathf.Max(maxSlowModeRegenerationTime, fishStatistic.slowModeRegenerationTime);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateMetrics();
        activeFishIndex = PlayerPrefs.GetInt("ActiveFish", activeFishIndex);
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
        activeFish = Instantiate(fishes[activeFishIndex], spawnPoint.position, Quaternion.identity, transform).AddComponent<FishController>();
        activeFish.SetTarget(demoPoint.position, false);
    }

    public void OnNextFishClick()
    {
        if (!activeFish.OnPlace())
        {
            return;
        }
        activeFishIndex += 1;
        if (activeFishIndex >= fishes.Length)
        {
            activeFishIndex = 0;
        }
        UpdateActiveFish();
    }

    public void OnPrevFishClick()
    {
        if (!activeFish.OnPlace())
        {
            return;
        }
        activeFishIndex -= 1;
        if (activeFishIndex < 0)
        {
            activeFishIndex = fishes.Length - 1;
        }
        UpdateActiveFish();
    }

    public void OnSelectFishClick()
    {
        PlayerPrefs.SetInt("ActiveFish", activeFishIndex);
    }

    public void OnCloseButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
