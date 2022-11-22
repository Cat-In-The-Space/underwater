using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static string PriceToText(int price)
    {
        if (price >= 1000)
        {
            return (price / 1000.0f).ToString("F2") + "k";
        }
        else
        {
            return price.ToString();
        }
    }

    public static string TimeToText(float time)
    {
        return Mathf.FloorToInt(time / 60.0f) + ":" + Mathf.FloorToInt(time % 60.0f);
    }

    public static bool IsAvailableFish(int index)
    {
        return PlayerPrefs.GetInt("Avaiable" + index + "Fish", 0) == 1;
    }

    public static void BuyFish(int index)
    {
        PlayerPrefs.SetInt("Avaiable" + index + "Fish", 1);
    }

    public static int GetActiveFishIndex()
    {
        return PlayerPrefs.GetInt("ActiveFish", 0);
    }

    public static bool HasActiveFishIndex()
    {
        return PlayerPrefs.HasKey("ActiveFish");
    }

    public static void SetActiveFishIndex(int index)
    {
        PlayerPrefs.SetInt("ActiveFish", index);
    }

    public static int GetBonus()
    {
        return PlayerPrefs.GetInt("Bonus", 0);
    }

    public static void SetBonus(int bonus)
    {
        PlayerPrefs.SetInt("Bonus", bonus);
    }

    public static float GetMaxLiveTime()
    {
        return PlayerPrefs.GetFloat("LiveTime", 0.0f);
    }

    public static void SetMaxLiveTime(float time)
    {
        PlayerPrefs.SetFloat("LiveTime", time);
    }

    public static float GetLevelLiveTime()
    {
        return PlayerPrefs.GetFloat("NewLiveTime", 0.0f);
    }
    public static void SetLevelLiveTime(float time)
    {
        PlayerPrefs.SetFloat("NewLiveTime", time);
    }
    public static int GetLevelBonus()
    {
        return PlayerPrefs.GetInt("NewBonus", 0);
    }
    public static void SetLevelBonus(int bonus)
    {
        PlayerPrefs.SetInt("NewBonus", bonus);
    }
}
