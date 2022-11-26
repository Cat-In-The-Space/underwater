using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip playClip, shopClip;
    public SplashScreenController splashScreen;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPlayClick()
    {
        audioSource.PlayOneShot(playClip);
        splashScreen.LoadScene("MainScene");
    }

    public void OnButtonStoreClick()
    {
        audioSource.PlayOneShot(shopClip);
        splashScreen.LoadScene("StoreScene");
    }
}
