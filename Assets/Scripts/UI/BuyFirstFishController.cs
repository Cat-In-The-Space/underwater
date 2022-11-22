using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFirstFishController : MonoBehaviour
{
    public int firstFishIndex = 0;
    void Start()
    {
        if (!Utils.HasActiveFishIndex())
        {
            Utils.BuyFish(firstFishIndex);
            Utils.SetActiveFishIndex(firstFishIndex);
        }
    }
}
