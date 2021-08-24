using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Cam Params")]
    public float dampTime = .15f;
    public float offsetY = 3f;
    public float offsetX = 0;

    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Camera camera;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta + new Vector3(offsetX, offsetY, 0);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
