using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelControllable
{
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep);
}
