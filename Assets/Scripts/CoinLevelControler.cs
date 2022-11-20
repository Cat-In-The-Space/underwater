using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLevelControler : MonoBehaviour, ILevelControllable
{
    public Transform coin;
    public void LevelInstantiated(LevelGeneratorController newLevelGeneratorController, Vector3 newLevelSize, float newFishMoveStep)
    {
        int sizeXinStep = Mathf.FloorToInt(newLevelSize.x / newFishMoveStep);
        int sizeYinStep = Mathf.FloorToInt(newLevelSize.y / newFishMoveStep);

        float x = Random.Range(0, sizeXinStep + 1) * newFishMoveStep - newLevelSize.x / 2.0f;
        float y = Random.Range(0, sizeYinStep + 1) * newFishMoveStep - newLevelSize.y / 2.0f;

        coin.localPosition = new Vector3(x, y, coin.localPosition.z);
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
