using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
#endif
using UnityEngine.UI;

public class ResultSceneResultPanelController : MonoBehaviour
{
    private float liveTime;
    private float newLiveTime;
    private int bonus;
    private int newBonus;

    public Text recordTimeText;
    public Text yourTimeText;
    public Text totalCoinsText;
    public Text yourCoinsText;
    public AudioSource audioSource;
    public AudioClip closeButtonClip;
    public SplashScreenController splashScreen;

    public int totalCoins;
    public float totalCoinsSpeed = 0.7f;
    public float elapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        liveTime = Utils.GetMaxLiveTime();
        newLiveTime = Utils.GetLevelLiveTime();
        bonus = Utils.GetBonus();
        newBonus = Utils.GetLevelBonus();

        recordTimeText.text = Utils.TimeToText(liveTime);
        yourTimeText.text = Utils.TimeToText(newLiveTime);
        yourCoinsText.text = Utils.PriceToText(newBonus);
        totalCoinsText.text = Utils.PriceToText(0);

        totalCoins = bonus + newBonus;
    }

    // Update is called once per frame
    void Update()
    {
        totalCoinsText.text = Utils.PriceToText(Mathf.FloorToInt(Mathf.Lerp(0.0f, totalCoins, elapsed * totalCoinsSpeed)));
        elapsed += Time.deltaTime;
    }

    public void OnCloseButtonClick()
    {
        int totalBonus = bonus + newBonus;
        audioSource.PlayOneShot(closeButtonClip);
        Utils.SetMaxLiveTime(Mathf.Max(liveTime, newLiveTime));
        Utils.SetBonus(totalBonus);
        #if ENABLE_CLOUD_SERVICES_ANALYTICS
        Analytics.CustomEvent("levelResult", new Dictionary<string, object> {
            {"liveTime", liveTime },
            {"newLiveTIme", newLiveTime },
            {"bonus", bonus },
            {"newBonus", newBonus },
            {"totalBonus", totalBonus }
        });
        #endif
        splashScreen.LoadScene("MainMenuScene");
    }
}
