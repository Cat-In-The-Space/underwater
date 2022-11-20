using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToSideItemController : EnemyItemController
{
    public LevelGeneratorController levelGeneratorController;
    public bool isInstantiated = false;
    public float maximalDistanceToPlayer;
    public Vector3 sourcePosition;
    public Vector3 targetPosition;
    public Quaternion initialRotation;
    public float showSideFactor = 0.1f;
    public bool controlRotation;
    public Vector3 moveVector;
    public bool continueMove;
    float GetDistanceToPlayer()
    {
        return transform.position.z - levelGeneratorController.fishController.transform.position.z;
    }
    public void EnemyInstantiated(LevelGeneratorController newLevelGeneratorController, 
        Vector2 newSourcePosition, Vector2 newTargetPosition, 
        bool newControlRotation, bool newContinueMove)
    {
        levelGeneratorController = newLevelGeneratorController;

        maximalDistanceToPlayer = GetDistanceToPlayer();

        sourcePosition = new Vector3(newSourcePosition.x, newSourcePosition.y, transform.position.z);
        targetPosition = new Vector3(newTargetPosition.x, newTargetPosition.y, transform.position.z);

        controlRotation = newControlRotation;
        continueMove = newContinueMove;
        isInstantiated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstantiated)
        {
            sourcePosition.z = transform.position.z;
            targetPosition.z = transform.position.z;

            float factor = Mathf.InverseLerp(maximalDistanceToPlayer, 0.0f, GetDistanceToPlayer());

            if (factor < 1.0f)
            {
                Vector3 position = Vector3.Lerp(sourcePosition, targetPosition, factor);

                moveVector = position - transform.position;
                Vector3 lookVector = new Vector3(moveVector.x, moveVector.y, -1.0f * showSideFactor * levelGeneratorController.speed);

                transform.position = position;
                if (controlRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookVector), Time.deltaTime);
                }
            }
            else
            {
                if (controlRotation)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime);
                }
                if (continueMove)
                {
                    transform.position += moveVector;
                }
            }
        }
    }
}
