using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelController : MonoBehaviour, ILevelControllable
{
    public GameObject[] availableEnemies;
    public GameObject[] availableBonuses;
    public float zBonusOffset;
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

        float x = Random.Range(0, sizeXinStep + 1) * newFishMoveStep - newLevelSize.x / 2.0f;
        float y = Random.Range(0, sizeYinStep + 1) * newFishMoveStep - newLevelSize.y / 2.0f;

        GameObject enemy = Instantiate(GetRandomEnemy(), new Vector3(x, y, transform.position.z - zOffset), Quaternion.LookRotation(-Vector3.forward), transform);
        if (Random.Range(0, 2) == 1 && availableBonuses.Length > 0)
        {
            Instantiate(GetRandomBonus(), new Vector3(x, y, transform.position.z - zOffset - zBonusOffset), Quaternion.identity, enemy.transform);
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
