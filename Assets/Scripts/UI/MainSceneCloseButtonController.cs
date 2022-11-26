using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneCloseButtonController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public Image confirmPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(clip);
        Time.timeScale = 0.0f;
        confirmPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
