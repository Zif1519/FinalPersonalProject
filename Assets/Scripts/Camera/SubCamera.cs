using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamera : MonoBehaviour
{
    public Transform mainCamera;
    public Transform smallBall;
    public Transform BigBall;
    
    void LateUpdate()
    {
        transform.position = (mainCamera.position-smallBall.position)*30f ;
        transform.rotation = mainCamera.rotation;
    }
}
