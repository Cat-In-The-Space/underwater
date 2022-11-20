using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManagerController
{
    private int mAmount;
    public BonusManagerController()
    {
        mAmount = PlayerPrefs.GetInt("bonus", 0);
    }
    public void AddBonus(int amount)
    {
        mAmount += amount;
    }
    public void StoreBonus()
    {
        PlayerPrefs.SetInt("bonus", mAmount);
    }
    public void SubBonus(int amount)
    {
        mAmount -= amount;
        PlayerPrefs.SetInt("bonus", mAmount);
    }
    public int GetAvailableBonus()
    {
        return mAmount;
    }
}
