using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelGeneratorController levelGeneratorController;
    public Vector3 levelSize;
    float fishMoveStep;
    public float levelDeep;
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        levelGeneratorController = newLevelGeneratorController;
        levelSize = newLevelSize;
        fishMoveStep = newFishMoveStep;
        foreach(ILevelControllable controller in GetComponents<ILevelControllable>())
        {
            controller.LevelInstantiated(levelGeneratorController, levelSize, fishMoveStep);
        }
    }
}
