using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMoRegenProgressBar : MonoBehaviour
{
    public StoreController storeController;
    private Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (storeController.fishStatistics[storeController.selectedFishIndex].canSlowMode)
        {
            progressBar.fillAmount = Mathf.InverseLerp(
                0,
                storeController.maxSlowModeRegenerationTime,
                storeController.maxSlowModeRegenerationTime - storeController.fishStatistics[storeController.selectedFishIndex].slowModeRegenerationTime
            );
        }
        else
        {
            progressBar.fillAmount = 0.0f;
        }
    }
}
