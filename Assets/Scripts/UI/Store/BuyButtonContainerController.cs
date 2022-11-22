using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonContainerController : MonoBehaviour
{
    public StoreController storeController;
    public GameObject buyButton;
    public Text price;
    void Update()
    {
        if (
            storeController.selectedFishIndex != storeController.activeFishIndex && 
            !storeController.fishAvailable[storeController.selectedFishIndex]
            )
        {
            price.text = Utils.PriceToText(storeController.fishStatistics[storeController.selectedFishIndex].cost);
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }
    }
}
