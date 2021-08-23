using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;

    void Start()
    {

    }

    void Update()
    {
        if(playerTransform != null)
        {
            transform.position = playerTransform.position - (Vector3.forward * 10);
        }
    }
}
