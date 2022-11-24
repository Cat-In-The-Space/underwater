using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSlowModeController : MonoBehaviour
{
    public LevelGeneratorController levelGeneratorController;
    public float levelSpeed;
    public float slowModeFactor = 0.75f;
    public float slowModeTime = 0.0f;
    public float slowModeElapsedTime = 0.0f;
    public float slowModeRegenerationTime = 0.0f;
    public float slowModeRegenerationElapsedTime = 0.0f;
    public ProgressBarController slowModeBar;
    public bool CanGoToSlowMode()
    {
        return slowModeRegenerationElapsedTime <= 0.0f;
    }
    public void SlowMode()
    {
        if (!CanGoToSlowMode())
        {
            return;
        }

        levelSpeed = levelGeneratorController.speed * slowModeFactor;
        levelGeneratorController.speed -= levelSpeed;

        slowModeElapsedTime += slowModeTime;
        slowModeRegenerationElapsedTime += slowModeRegenerationTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        slowModeBar.speed = 1.0f / slowModeTime;
    }

    // Update is called once per frame
    void Update()
    {
        slowModeBar.SetValue(slowModeRegenerationTime - slowModeRegenerationElapsedTime, slowModeRegenerationTime);

        if (slowModeElapsedTime > 0.0f)
        {
            slowModeElapsedTime -= Time.deltaTime;
        }
        else
        {
            levelGeneratorController.speed += levelSpeed;
            levelSpeed = 0.0f;
        }

        if (!CanGoToSlowMode())
        {
            slowModeRegenerationElapsedTime -= Time.deltaTime;
        }
    }
}
