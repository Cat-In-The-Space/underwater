using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowModeGroupController : MonoBehaviour
{
    public FishSlowModeController fishSlowModeController;
    public GameObject slowModeBar;
    void Update()
    {
        slowModeBar.SetActive(fishSlowModeController.enabled);
    }
}
