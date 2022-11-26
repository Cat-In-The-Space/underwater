using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSlowModeController : MonoBehaviour
{
    private enum Status
    {
        WAIT,
        ACTIVE,
        REGENERATE
    }
    private Status status = Status.WAIT;
    private float speedDecreaseBy;
    private float timer;

    public LevelGeneratorController levelGeneratorController;
    public AudioSource audioSource;
    public AudioClip clip;
    public Image progressBar;
    [Range(0.0f, 1.0f)]
    public float slowModeFactor = 0.75f;
    public float slowModeTime = 0.0f;
    public float slowModeRegenerationTime = 0.0f;
    public ProgressBarController slowModeBar;
    public string joystickName = "Fish";
    [Range(0.0f, 1.0f)]
    public float tapMaxMoveDistance = 0.5f;

    public void SlowMode()
    {
        if (status != Status.WAIT)
        {
            return;
        }
        status = Status.ACTIVE;

        audioSource.PlayOneShot(clip);

        speedDecreaseBy = levelGeneratorController.speed * slowModeFactor;
        levelGeneratorController.speed -= speedDecreaseBy;

        timer = slowModeTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status == Status.ACTIVE)
        {
            timer -= Time.deltaTime;
            progressBar.fillAmount = Mathf.InverseLerp(0, slowModeTime, timer);
            if (timer <= 0.0f)
            {
                levelGeneratorController.speed += speedDecreaseBy;
                speedDecreaseBy = 0.0f;

                status = Status.REGENERATE;
                timer += slowModeRegenerationTime;
            }
        }
        else if (status == Status.REGENERATE)
        {
            timer -= Time.deltaTime;
            progressBar.fillAmount = Mathf.InverseLerp(0, slowModeRegenerationTime, slowModeRegenerationTime - timer);
            if (timer <= 0.0f)
            {
                status = Status.WAIT;
                timer = 0.0f;
            }
        }
        else if (status == Status.WAIT)
        {
            if (UltimateJoystick.GetTapCount(joystickName) && (UltimateJoystick.GetDistance(joystickName) < tapMaxMoveDistance))
            {
                SlowMode();
            }
        }
    }
}
