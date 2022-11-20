using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLevelItemController : MonoBehaviour
{
    public float rotationSpeed;
    public int amount;
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
        if (other.gameObject.CompareTag("Player") || (other.transform.parent != null && other.transform.parent.CompareTag("Player")))
        {
            Destroy(gameObject);
            ManagerController.GetInstance().bonusManager.AddBonus(amount);
        }
    }
}
