using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class MagnetController : MonoBehaviour
{
    FishController fishController;
    public LayerMask layers;
    Collider[] colliders;
    public int maxCollide = 100;
    // Start is called before the first frame update
    void Start()
    {
        fishController = GetComponent<FishController>();
        colliders = new Collider[maxCollide];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float radius = 1.5f * fishController.moveStep;
        int triggered = Physics.OverlapSphereNonAlloc(position, radius, colliders, layers);
        for (int i = 0; i < triggered; ++i)
        {
            colliders[i].GetComponent<MagnetEffectController>().Initialize(position);
        }
    }
}
