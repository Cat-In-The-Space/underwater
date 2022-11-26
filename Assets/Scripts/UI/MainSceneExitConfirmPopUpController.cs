using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneExitConfirmPopUpController : MonoBehaviour
{
    public Image mainSceneExitButton;
    public AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCancelButtonClick()
    {
        audioSource.PlayOneShot(clip);
        gameObject.SetActive(false);
        mainSceneExitButton.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void OnOkButtonClick()
    {
        audioSource.PlayOneShot(clip);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
