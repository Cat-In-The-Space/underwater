using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRushForwardLevelController : MonoBehaviour, ILevelControllable
{
    public GameObject[] availableEnemies;
    public float zOffset;
    GameObject GetRandomEnemy()
    {
        return availableEnemies[Random.Range(0, availableEnemies.Length)];
    }
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        int sizeXinStep = Mathf.FloorToInt(newLevelSize.x / newFishMoveStep);
        int sizeYinStep = Mathf.FloorToInt(newLevelSize.y / newFishMoveStep);

        int xInStep = Random.Range(0, sizeXinStep + 1);
        int yInStep = Random.Range(0, sizeYinStep + 1);

        float x = (xInStep * newFishMoveStep) - (newLevelSize.x / 2.0f);

        for (int i = 0; i <= sizeYinStep; ++i)
        {
            float yi = (i * newFishMoveStep) - newLevelSize.y / 2.0f;
            Instantiate(GetRandomEnemy(), new Vector3(x, yi, transform.position.z - zOffset), Quaternion.LookRotation(-Vector3.forward), transform);
        }

        float y = (yInStep * newFishMoveStep) - (newLevelSize.y / 2.0f);

        for (int i = 0; i <= sizeXinStep; ++i)
        {
            if (i == xInStep)
            {
                continue;
            }
            float xi = (i * newFishMoveStep) - newLevelSize.x / 2.0f;
            Instantiate(GetRandomEnemy(), new Vector3(xi, y, transform.position.z - zOffset), Quaternion.LookRotation(-Vector3.forward), transform);
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
