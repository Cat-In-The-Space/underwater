using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowModeGroupController : MonoBehaviour
{
    public FishSlowModeController fishSlowModeController;
    public GameObject slowModeBar;
    public GameObject slowModeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fishSlowModeController.enabled)
        {
            slowModeBar.SetActive(true);
            if (fishSlowModeController.CanGoToSlowMode())
            {
                //slowModeButton.SetActive(true);
            }
            else
            {
              //  slowModeButton.SetActive(false);
            }
        }
        else
        {
            slowModeBar.SetActive(false);
            //slowModeButton.SetActive(false);
        }
    }
}
