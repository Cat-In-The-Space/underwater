using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelController : MonoBehaviour, ILevelControllable
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

        float x = Random.Range(0, sizeXinStep + 1) * newFishMoveStep - newLevelSize.x / 2.0f;
        float y = Random.Range(0, sizeYinStep + 1) * newFishMoveStep - newLevelSize.y / 2.0f;

        Instantiate(GetRandomEnemy(), new Vector3(x, y, transform.position.z - zOffset), Quaternion.LookRotation(-Vector3.forward), transform);
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
