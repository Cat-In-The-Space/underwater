using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEffectController : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 targetPosition;
    float magnetSpeed = 1.0f;
    float takeTime = 0.0f;
    public void Initialize(Vector3 newTargetPosition)
    {
        transform.parent = null;
        initialPosition = transform.position;
        targetPosition = newTargetPosition;
        enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(initialPosition, targetPosition, takeTime);
        takeTime += magnetSpeed * Time.deltaTime;
    }
}
