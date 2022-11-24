using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRushLevelController : MonoBehaviour, ILevelControllable
{
    public GameObject[] availableEnemies;
    public GameObject[] availableBonuses;
    public float zOffset;
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

        Quaternion rotation;
        Vector2[] sourcePositions = new Vector2[sizeYinStep + 1];
        Vector2[] targetPositions = new Vector2[sizeYinStep + 1];
        if (Random.Range(0, 2) == 0)
        {   // Rush from left to right
            rotation = Quaternion.LookRotation(Vector3.right);
            for (int i = 0; i < sizeYinStep + 1; ++i)
            {
                sourcePositions[i].x = (-sizeXinStep / 2.0f) * newFishMoveStep;
                targetPositions[i].x = (sizeXinStep / 2.0f) * newFishMoveStep;
                sourcePositions[i].y = targetPositions[i].y = i * newFishMoveStep - newLevelSize.y / 2.0f;
            }
        }
        else
        {   // Rush from right to left
            rotation = Quaternion.LookRotation(Vector3.left);
            for (int i = 0; i < sizeYinStep + 1; ++i)
            {
                sourcePositions[i].x = (sizeXinStep / 2.0f) * newFishMoveStep;
                targetPositions[i].x = (-sizeXinStep / 2.0f) * newFishMoveStep;
                sourcePositions[i].y = targetPositions[i].y = i * newFishMoveStep - newLevelSize.y / 2.0f;
            }
        }

        for (int i = 0; i < sizeYinStep + 1; ++i)
        {
            Vector3 spawnPosition = new Vector3(sourcePositions[i].x, sourcePositions[i].y, transform.position.z - zOffset);

            GameObject enemy = Instantiate(GetRandomEnemy(), spawnPosition, rotation, transform);
            enemy.GetComponent<EnemyToSideItemController>().EnemyInstantiated(newLevelGeneratorController, sourcePositions[i], targetPositions[i], false, true);
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(GetRandomBonus(), enemy.transform.TransformPoint(0.0f, 0.0f, -1.0f * newFishMoveStep), Quaternion.identity, enemy.transform);
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
