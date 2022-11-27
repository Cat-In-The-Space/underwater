using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxItemController : MonoBehaviour
{
    public GameObject[] decors;
    public Transform[] positions;
    [Range(0.0f, 1.0f)]
    public float showFactor = 0.7f;

    public void Refresh()
    {
        foreach (Transform parent in positions)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
            if (Random.Range(0.0f, 1.0f) < showFactor)
            {
                Instantiate(decors[Random.Range(0, decors.Length)], parent.position, Quaternion.identity, parent);
            }
        }
    }
}
