using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemController : MonoBehaviour
{
    public int damage;
    public AudioClip clip;
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
        FishHealthController fishHealthController = null;
        if (other.gameObject.CompareTag("Player"))
        {
            fishHealthController = other.GetComponent<FishHealthController>();
        } 
        else if (other.transform.parent != null && other.transform.parent.CompareTag("Player"))
        {
            fishHealthController = other.transform.parent.GetComponent<FishHealthController>();
        }
        if (fishHealthController)
        {
            if (fishHealthController.Damage(damage))
            {
                fishHealthController.GetComponent<AudioSource>().PlayOneShot(clip);
                Destroy(gameObject);
            }
        }
    }
}
