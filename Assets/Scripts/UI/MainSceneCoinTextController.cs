using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneCoinTextController : MonoBehaviour
{
    private Text text;
    public FishBonusController fishBonusController;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Utils.PriceToText(fishBonusController.bonuses);
    }
}
