using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTarget;
    public float xOffset, yOffset;

    void Update()
    {
        transform.position = new Vector3(
            cameraTarget.position.x + xOffset,
            cameraTarget.position.y + yOffset,
            transform.position.z);
    }
}
