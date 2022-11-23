using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLoadController : MonoBehaviour
{
    public GameObject[] fishes; // WARNING! Same order like in shop
    void Start()
    {
        GameObject fish = Instantiate(fishes[Utils.GetActiveFishIndex()], transform.position, transform.rotation, transform);
        FishStatisticController fishStatistic = fish.GetComponent<FishStatisticController>();

        FishController fishController = GetComponent<FishController>();
        fishController.moveSpeed = fishStatistic.moveSpeed;

        FishHealthController fishHealthController = GetComponent<FishHealthController>();
        fishHealthController.Initialize(fishStatistic.maxHealth);
        if (fishStatistic.canHealthRegenerate)
        {
            fishHealthController.canRegenerate = true;
            fishHealthController.regenerationTime = fishStatistic.healthRegenerationTime;
        }
        else
        {
            fishHealthController.canRegenerate = false;
        }

        FishSlowModeController fishSlowModeController = GetComponent<FishSlowModeController>();
        if (fishStatistic.canSlowMode)
        {
            fishSlowModeController.enabled = true;
            fishSlowModeController.slowModeRegenerationTime = fishStatistic.slowModeRegenerationTime;
        }
        else
        {
            fishSlowModeController.enabled = false;
        }

        MagnetController magnetController = GetComponent<MagnetController>();
        magnetController.enabled = fishStatistic.haveMagnet;
    }
}
