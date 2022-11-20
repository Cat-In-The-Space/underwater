using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController
{
    public void GoToScene(string sceneName)
    {
        ManagerController.GetInstance().bonusManager.StoreBonus();
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        ManagerController.GetInstance().bonusManager.StoreBonus();
        Application.Quit();
    }
}
