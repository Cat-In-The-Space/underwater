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

        BoxCollider boxCollider = GetComponent<BoxCollider>();

        // (fish moveStep/2) . maxX ... 0 ... minX . (fish moveStep/2)
        boxCollider.size = new Vector3(levelSize.x + fishMoveStep, levelSize.y + fishMoveStep, boxCollider.size.z);

        foreach(ILevelControllable controller in GetComponents<ILevelControllable>())
        {
            controller.LevelInstantiated(levelGeneratorController, levelSize, fishMoveStep);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || (other.transform.parent != null && other.transform.parent.CompareTag("Player")))
        {
            levelGeneratorController.LevelCompleted();
            Destroy(gameObject);
        }
    }
}
