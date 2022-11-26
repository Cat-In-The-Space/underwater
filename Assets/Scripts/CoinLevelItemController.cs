using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLevelItemController : MonoBehaviour
{
    public float rotationSpeed;
    public int amount;
    public AudioClip triggerSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        FishBonusController fishBonusController = null;
        if (other.gameObject.CompareTag("Player"))
        {
            fishBonusController = other.GetComponent<FishBonusController>();
        }
        else if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            fishBonusController = other.transform.parent.GetComponent<FishBonusController>();
        }
        if (fishBonusController)
        {
            fishBonusController.GetComponent<AudioSource>().PlayOneShot(triggerSound);
            fishBonusController.bonuses += amount;
            Destroy(gameObject);
        }
    }
}
