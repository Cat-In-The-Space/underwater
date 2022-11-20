using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController
{
    private static ManagerController instance = null;
    public BonusManagerController bonusManager { get; private set; }
    public SceneManagerController sceneManager { get; private set; }
    public static ManagerController GetInstance()
    {
        if (instance == null)
        {
            instance = new ManagerController();
            instance.bonusManager = new BonusManagerController();
            instance.sceneManager = new SceneManagerController();
        }
        return instance;
    }
}
