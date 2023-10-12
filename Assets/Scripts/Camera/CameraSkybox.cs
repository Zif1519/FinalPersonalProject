using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSkybox : MonoBehaviour
{
    public Transform smallBall;
    public Transform mainCamera;
    public Transform player;

    private void Update()
    {
        transform.localPosition = (player.position - smallBall.position)/30f;
        transform.rotation = mainCamera.rotation;
    }
}
