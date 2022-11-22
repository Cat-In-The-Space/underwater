using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButtonContainerController : MonoBehaviour
{
    public StoreController storeController;
    public GameObject selectButton;
    void Update()
    {
        if (
            storeController.selectedFishIndex != storeController.activeFishIndex &&
            storeController.fishAvailable[storeController.selectedFishIndex]
            )
        {
            selectButton.SetActive(true);
        }
        else
        {
            selectButton.SetActive(false);
        }
    }
}
