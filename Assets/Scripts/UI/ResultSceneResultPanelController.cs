using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public int totalCoins;
    public float totalCoinsSpeed = 0.5f;
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
        if (newLiveTime > liveTime)
        {
            Utils.SetMaxLiveTime(newLiveTime);
        }
        Utils.SetBonus(bonus + newBonus);
        SceneManager.LoadScene("MainMenuScene");
    }
}
