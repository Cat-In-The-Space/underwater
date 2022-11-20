using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public string joystickName = "Fish";
    public bool canMove = true;
    public Vector3 targetPosition;
    public float moveStep = 1.0f;

    public float minX = -1.0f;
    public float maxX = 1.0f;
    public float minY = -1.0f;
    public float maxY = 1.0f;

    public float moveSpeed = 1.0f;
    public Quaternion initialRotation;
    public float rotationSpeed = 1.0f;
    public float rotationFactor = 0.5f; // Greatest - more sides

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    bool onPlace()
    {
        return Vector3.Distance(transform.localPosition, targetPosition) < 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (onPlace())
        {
            canMove = true;
        }
        if (canMove)
        {
            float h = UltimateJoystick.GetHorizontalAxis(joystickName);

            if (h > 0.5f)
            {
                targetPosition.x += moveStep;
            }
            else if (h < -0.5f)
            {
                targetPosition.x -= moveStep;
            }
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

            float v = UltimateJoystick.GetVerticalAxis(joystickName);

            if (v > 0.5f)
            {
                targetPosition.y += moveStep;
            }
            else if (v < -0.5f)
            {
                targetPosition.y -= moveStep;
            }
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            if (!onPlace())
            {
                canMove = false;
            }
        } 

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);

        // Warn! LookRotation make rotation in global coordinates (from point (0,0,0) to (globalX, globalY, globalZ))
        Vector3 look = targetPosition - transform.localPosition;
        look.z = moveSpeed * rotationFactor;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(look), rotationSpeed * Time.deltaTime);
    }
}
