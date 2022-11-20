using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEffectController : MonoBehaviour
{
    public float magnetSpeed = 1.0f;
    Transform targetTransform;
    public void MoveTo(Transform newTargetTransform)
    {
        transform.parent = null;
        targetTransform = newTargetTransform;
        enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (targetTransform.position - transform.position).normalized * magnetSpeed * Time.deltaTime;
    }
}
