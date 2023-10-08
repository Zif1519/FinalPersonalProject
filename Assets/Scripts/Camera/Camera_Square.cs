using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Square : MonoBehaviour
{
    public Transform mainCamera;
    public Transform smallBall;

    private void Update()
    {
        transform.rotation = mainCamera.rotation;
        transform.position = mainCamera.forward * -50f;
    }
}
