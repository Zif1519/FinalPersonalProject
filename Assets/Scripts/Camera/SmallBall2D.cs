using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall2D : MonoBehaviour
{
    public Transform mainCamera;
    public Transform smallBall;

    private void Update()
    {
        transform.rotation = mainCamera.rotation*Quaternion.Euler(new Vector3(270f,270f,270f));
    }
}
