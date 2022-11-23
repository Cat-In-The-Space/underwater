using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorController : MonoBehaviour
{
    public FishController fishController;
    public GameObject[] availableLevels;
    public LinkedList<LevelController> activeLevels;
    public int activeLevelsCount = 3;
    public Vector3 levelSize;
    public float speed = 1.0f;
    public float speedIncreaseFactor = 1.01f;
    public float maxSpeed = 10.0f;

    public ParallaxItemController[] parallaxes;
    public int currentParallax = 0;
    public Transform parallaxSpawner;
    public Vector3 parallaxResetDistance;

    GameObject GetRandomLevel()
    {
        return availableLevels[Random.Range(0, availableLevels.Length)];
    }

    LevelController InstantiateNewLevel(float z)
    {
        GameObject level = Instantiate(GetRandomLevel(), transform);
        LevelController levelController = level.GetComponent<LevelController>();
        level.transform.localPosition = new Vector3(0.0f, 0.0f, z + levelController.levelDeep);
        levelController.LevelInstantiated(this, levelSize, fishController.moveStep);
        return levelController;
    }
    // Start is called before the first frame update
     void Start()
     {
        levelSize = new Vector3(fishController.maxX - fishController.minX, fishController.maxY - fishController.minY);
        activeLevels = new LinkedList<LevelController>();

        float z = 0.0f;
        for (int i = 0; i < activeLevelsCount; ++i)
        {
            LevelController levelController = InstantiateNewLevel(z);
            activeLevels.AddLast(levelController);
            z += levelController.levelDeep;
        }

        parallaxResetDistance = parallaxSpawner.localPosition - parallaxes[currentParallax].transform.localPosition;
        parallaxes[currentParallax].Refresh();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0.0f, 0.0f, -1.0f) * speed * Time.deltaTime;
        UpdateLevels(move);
        UpdateParallax(move);
    }

    void UpdateLevels(Vector3 move)
    {
        foreach (LevelController level in activeLevels)
        {
            level.transform.localPosition += move;
        }
    }

    void UpdateParallax(Vector3 move)
    {
        foreach (ParallaxItemController parallax in parallaxes)
        {
            parallax.transform.localPosition += move;
        }
        int nextParallax = currentParallax + 1;
        if (nextParallax >= parallaxes.Length)
        {
            nextParallax = 0;
        }
        if (parallaxes[nextParallax].transform.position.z < fishController.transform.position.z)
        {
            parallaxes[currentParallax].transform.localPosition += parallaxResetDistance;
            currentParallax = nextParallax;
            parallaxes[currentParallax].Refresh();
        }
    }

    public void LevelCompleted()
    {
        activeLevels.RemoveFirst();
        activeLevels.AddLast(InstantiateNewLevel(activeLevels.Last.Value.transform.localPosition.z));
        speed = Mathf.Min(speed * speedIncreaseFactor, maxSpeed);
    }
}
