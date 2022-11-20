using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFishSpawnerController : MonoBehaviour
{
    public class SwimController : MonoBehaviour
    {
        public float swimSpeed;
        public float swimDistance;
        public Vector3 startPosition;
        void Start()
        {
            startPosition = transform.position;
        }
        void Update()
        {
            transform.position += transform.forward * swimSpeed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) > swimDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    public GameObject[] fishes;
    public float minSpawnAngle = -30.0f;
    public float maxSpawnAngle = 30.0f;
    public float minSpawnTime = 2.0f;
    public float maxSpawnTime = 5.0f;
    public float timeToSpawn = 0.0f;
    public float minSwimSpeed = 1.0f;
    public float maxSwimSpeed = 2.0f;
    public float swimDistance = 10.0f;
    void SpawnRandomFish()
    {
        GameObject fish = Instantiate(
            fishes[Random.Range(0, fishes.Length)], 
            transform.position, 
            Quaternion.LookRotation(transform.forward) * Quaternion.Euler(Random.Range(minSpawnAngle, maxSpawnAngle), 0.0f, 0.0f), 
            transform);
        SwimController swimController = fish.AddComponent<SwimController>();
        swimController.swimSpeed = Random.Range(minSwimSpeed, maxSwimSpeed);
        swimController.swimDistance = swimDistance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn > 0.0f)
        {
            timeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnRandomFish();
            timeToSpawn += Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
