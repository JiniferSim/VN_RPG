using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    public bool boarder;

    public float minX;
    public float maxX;

    void Update()
    {
        if(boarder == true)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(target.position.x, transform.position.y, -10);
        }
    }
}
