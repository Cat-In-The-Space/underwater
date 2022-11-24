using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToSideLevelController : MonoBehaviour, ILevelControllable
{
    public enum Side
    {
        HORIZONTAL = 0,
        VERTICAL = 1
    };

    public Side side;
    public GameObject[] availableEnemies;
    public GameObject[] availableBonuses;
    public float zOffset;
    public float zBonusOffset;
    GameObject GetRandomEnemy()
    {
        return availableEnemies[Random.Range(0, availableEnemies.Length)];
    }
    GameObject GetRandomBonus()
    {
        return availableBonuses[Random.Range(0, availableBonuses.Length)];
    }
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        int sizeXinStep = Mathf.FloorToInt(newLevelSize.x / newFishMoveStep);
        int sizeYinStep = Mathf.FloorToInt(newLevelSize.y / newFishMoveStep);

        Vector2 sourcePosition = new Vector2();
        Vector2 targetPosition = new Vector2();
        if (side == Side.HORIZONTAL)
        {
            if (Random.Range(0, 2) == 0)
            {   // From left to right
                sourcePosition.x = (-sizeXinStep / 2.0f) * newFishMoveStep;
                targetPosition.x = (sizeXinStep / 2.0f) * newFishMoveStep;
            }
            else
            {   // From right to left
                sourcePosition.x = (sizeXinStep / 2.0f) * newFishMoveStep;
                targetPosition.x = (-sizeXinStep / 2.0f) * newFishMoveStep;
            }
            sourcePosition.y = targetPosition.y = (Random.Range(0, sizeYinStep + 1) * newFishMoveStep) - newLevelSize.y / 2.0f;
        }
        else if (side == Side.VERTICAL)
        {
            if (Random.Range(0, 2) == 0)
            {   // From up to down
                sourcePosition.y = (sizeYinStep / 2.0f) * newFishMoveStep;
                targetPosition.y = (-sizeYinStep / 2.0f) * newFishMoveStep;
            }
            else
            {   // From down to up
                sourcePosition.y = (-sizeYinStep / 2.0f) * newFishMoveStep;
                targetPosition.y = (sizeYinStep / 2.0f) * newFishMoveStep;
            }
            sourcePosition.x = targetPosition.x = (Random.Range(0, sizeXinStep + 1) * newFishMoveStep) - newLevelSize.x / 2.0f;
        }

        Vector3 spawnPosition = new Vector3(sourcePosition.x, sourcePosition.y, transform.position.z - zOffset);

        GameObject enemy = Instantiate(GetRandomEnemy(), spawnPosition, Quaternion.LookRotation(-Vector3.forward), transform);
        enemy.GetComponent<EnemyToSideItemController>().EnemyInstantiated(newLevelGeneratorController, sourcePosition, targetPosition, true, false);
        Instantiate(GetRandomBonus(), enemy.transform.TransformPoint(0.0f, 0.0f, zBonusOffset), Quaternion.identity, enemy.transform);
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
