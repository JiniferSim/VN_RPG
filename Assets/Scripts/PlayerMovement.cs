using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private float _speed = 15f;

    [SerializeField] private float jumpForce = 6;

    [SerializeField] private LayerMask floorLayer;

    private float horizontalMovement;
    private float horizontalVelocity;

    private bool grounded;

    private Rigidbody2D rb;
    //private GameObject _cameraFollow;

    private Animator animator;

    private void Awake()
    {
        //_cameraFollow = GameObject.Find("CameraFollowPlayer");
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        //_cameraFollowObject = _cameraFollow.GetComponent<CameraFollowPlayer>();
        //_fallSpeedYThresholdChange = CameraManager.instance._fallspeedYThresholdChange;
    }


    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            MoveAndFlipSprite();
        }

        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        grounded = false;
    }

    void MoveAndFlipSprite()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        // Flip the sprite if moving to the left
        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Flip the sprite if moving to the right
        else if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 movement = new Vector2(moveDirection * _speed, rb.velocity.y);
        rb.velocity = movement;

        animator.SetBool("IsWalking", Mathf.Abs(moveDirection) > 0);
    }
}
