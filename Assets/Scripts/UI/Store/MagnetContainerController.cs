using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetContainerController : MonoBehaviour
{
    public StoreController storeController;
    public GameObject magnetYes, magnetNo;
    void Update()
    {
        if (storeController.fishStatistics[storeController.selectedFishIndex].haveMagnet)
        {
            magnetYes.SetActive(true);
            magnetNo.SetActive(false);
        }
        else
        {
            magnetYes.SetActive(false);
            magnetNo.SetActive(true);
        }
    }
}
