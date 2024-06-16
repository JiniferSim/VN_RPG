using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public float FollowSpeed = 2f;
    //public float yOffset = 1f;
    [SerializeField] private Transform target;

    private Vector2 offset = new Vector2 (0f, 0f);
    private float smoothTime = 0.25f;
    private Vector2 velocity = Vector2.zero;

    void Update()
    {
        //Vector3 newPos = new Vector3(target.position.x, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

        //Vector2 targetPosition = target.position.x;
        //transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.position = new Vector3(target.position.x, transform.position.y, -10);
    }
}
