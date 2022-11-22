using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceController : MonoBehaviour
{
    public StoreController storeController;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = Utils.PriceToText(storeController.playerBonus);
    }
}
