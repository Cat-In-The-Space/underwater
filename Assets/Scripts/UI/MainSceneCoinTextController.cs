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
        if (fishBonusController.bonuses >= 1000)
        {
            text.text = (fishBonusController.bonuses / 1000.0f).ToString("F2") + "k";
        }
        else
        {
            text.text = fishBonusController.bonuses.ToString();
        }
    }
}
