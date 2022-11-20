using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerProxyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToScene(string sceneName)
    {
        ManagerController.GetInstance().sceneManager.GoToScene(sceneName);
    }
    public void Quit()
    {
        ManagerController.GetInstance().sceneManager.Quit();
    }
}
