using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgressBarController : MonoBehaviour
{
    private Image progressBar;
    public StoreController storeController;
    // Start is called before the first frame update
    void Start()
    {
        progressBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.fillAmount = Mathf.InverseLerp(0, storeController.maxHealth, storeController.fishStatistics[storeController.selectedFishIndex].maxHealth);
    }
}
