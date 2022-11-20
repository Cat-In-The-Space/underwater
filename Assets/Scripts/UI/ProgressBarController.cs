using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Image progress;
    public float newFillAmount;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        newFillAmount = progress.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (newFillAmount > progress.fillAmount)
        {
            progress.fillAmount = Mathf.Min(progress.fillAmount + speed * Time.deltaTime, newFillAmount);
        }
        else if (newFillAmount < progress.fillAmount)
        {
            progress.fillAmount = Mathf.Max(progress.fillAmount - speed * Time.deltaTime, newFillAmount);
        }
    }

    public void SetValue(int value, int maxValue)
    {
        newFillAmount = Mathf.InverseLerp(0, maxValue, value);
    }

    public void SetValue(float value, float maxValue)
    {
        newFillAmount = Mathf.InverseLerp(0, maxValue, value);
    }
}
