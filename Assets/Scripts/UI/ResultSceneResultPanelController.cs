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
    string TimeToText(float t)
    {
        return Mathf.FloorToInt(t / 60.0f) + ":" + Mathf.FloorToInt(t % 60.0f);
    }
    string BonusToText(int bonus)
    {
        if (bonus >= 1000)
        {
            return (bonus / 1000.0f).ToString("F2") + "k";
        }
        else
        {
            return bonus.ToString();
        }
    }
    void Start()
    {
        liveTime = PlayerPrefs.GetFloat("LiveTime", 0.0f);
        newLiveTime = PlayerPrefs.GetFloat("NewLiveTime", 0.0f);
        bonus = PlayerPrefs.GetInt("Bonus", 0);
        newBonus = PlayerPrefs.GetInt("NewBonus", 0);

        recordTimeText.text = TimeToText(liveTime);
        yourTimeText.text = TimeToText(newLiveTime);
        yourCoinsText.text = BonusToText(newBonus);
        totalCoinsText.text = BonusToText(0);

        totalCoins = bonus + newBonus;
    }

    // Update is called once per frame
    void Update()
    {
        totalCoinsText.text = BonusToText(Mathf.FloorToInt(Mathf.Lerp(0.0f, totalCoins, elapsed * totalCoinsSpeed)));
        elapsed += Time.deltaTime;
    }

    public void OnCloseButtonClick()
    {
        if (newLiveTime > liveTime)
        {
            PlayerPrefs.SetFloat("LiveTime", newLiveTime);
        }
        PlayerPrefs.SetInt("Bonus", bonus + newBonus);
        SceneManager.LoadScene("MainMenuScene");
    }
}
