using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRushOForwardLevelController : MonoBehaviour, ILevelControllable
{
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
    void SpawnEnemy(float x, float y)
    {
        GameObject enemy = Instantiate(GetRandomEnemy(), new Vector3(x, y, transform.position.z - zOffset), Quaternion.LookRotation(-Vector3.forward), transform);
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(GetRandomBonus(), enemy.transform.TransformPoint(0.0f, 0.0f, zBonusOffset), Quaternion.identity, enemy.transform);
        }
    }
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        int sizeXinStep = Mathf.FloorToInt(newLevelSize.x / newFishMoveStep);
        int sizeYinStep = Mathf.FloorToInt(newLevelSize.y / newFishMoveStep);

        float x, y;
        for (int i = 0; i <= sizeXinStep; ++i)
        {
            x = (i * newFishMoveStep) - newLevelSize.x / 2.0f;
            SpawnEnemy(x, (sizeYinStep * newFishMoveStep) / 2.0f);
            SpawnEnemy(x, (-sizeYinStep * newFishMoveStep) / 2.0f);
        }
        for (int i = 1; i < sizeYinStep; ++i)
        {
            y = (i * newFishMoveStep) - newLevelSize.y / 2.0f;
            SpawnEnemy((-sizeXinStep * newFishMoveStep) / 2.0f, y);
            SpawnEnemy((sizeXinStep * newFishMoveStep) / 2.0f, y);
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
