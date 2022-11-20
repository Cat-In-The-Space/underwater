using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSceneController : MonoBehaviour
{
    public GameObject[] fishes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
