using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineToSideLevelController : MonoBehaviour, ILevelControllable
{
    public enum Side
    {
        HORIZONTAL = 0,
        VERTICAL = 1
    };

    public LevelGeneratorController levelGeneratorController;
    public Side side;
    public GameObject[] availableEnemies;
    public float zOffset;
    GameObject GetRandomEnemy()
    {
        return availableEnemies[Random.Range(0, availableEnemies.Length)];
    }
    void SpawnEnemy(Vector3 sourcePosition, Vector3 targetPosition)
    {
        Vector3 spawnPosition = new Vector3(sourcePosition.x, sourcePosition.y, transform.position.z - zOffset);

        GameObject enemy = Instantiate(GetRandomEnemy(), spawnPosition, Quaternion.LookRotation(-Vector3.forward), transform);
        enemy.GetComponent<EnemyToSideItemController>().EnemyInstantiated(levelGeneratorController, sourcePosition, targetPosition, true, false);
    }
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        levelGeneratorController = newLevelGeneratorController;

        int sizeXinStep = Mathf.FloorToInt(newLevelSize.x / newFishMoveStep);
        int sizeYinStep = Mathf.FloorToInt(newLevelSize.y / newFishMoveStep);

        if (side == Side.HORIZONTAL)
        {
            float sourceX, targetX, yi;
            if (Random.Range(0, 2) == 0)
            {   // From left to right
                sourceX = (-sizeXinStep / 2.0f) * newFishMoveStep;
                targetX = (sizeXinStep / 2.0f) * newFishMoveStep;
            }
            else
            {   // From right to left
                sourceX = (sizeXinStep / 2.0f) * newFishMoveStep;
                targetX = (-sizeXinStep / 2.0f) * newFishMoveStep;
            }
            for (int i = 0; i <= sizeYinStep; ++i)
            {
                yi = (i * newFishMoveStep) - newLevelSize.y / 2.0f;
                SpawnEnemy(new Vector3(sourceX, yi), new Vector3(targetX, yi));
            }
        }
        else if (side == Side.VERTICAL)
        {
            float sourceY, targetY, xi;
            if (Random.Range(0, 2) == 0)
            {   // From up to down
                sourceY = (sizeYinStep / 2.0f) * newFishMoveStep;
                targetY = (-sizeYinStep / 2.0f) * newFishMoveStep;
            }
            else
            {   // From down to up
                sourceY = (-sizeYinStep / 2.0f) * newFishMoveStep;
                targetY = (sizeYinStep / 2.0f) * newFishMoveStep;
            }
            for (int i = 0; i <= sizeXinStep; ++i)
            {
                xi = (i * newFishMoveStep) - newLevelSize.x / 2.0f;
                SpawnEnemy(new Vector3(xi, sourceY), new Vector3(xi, targetY));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}