using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

#region Required Components

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

#endregion
public class PlayerController : MonoBehaviour
{
    #region Variable

    [Header("Scriptable Object Data")]
    [SerializeField] private PlayerData playerData;
    
    [Header("Controller Component")]
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private bool isFacingRight;
    private Transform aimTransform;
    
    public GroundStats groundStats;
    
    [Header("Reference")]
    private Rigidbody2D myRb;
    private Animator myAnim;

    #endregion

    #region Struct

    [Serializable]
    public struct GroundStats
    {
        public Transform groundCheck;
        public float groundRadius;
        public LayerMask whatIsGround;
    }

    #endregion

    private void Awake()
    {
        myRb = GetComponentInChildren<Rigidbody2D>();
        myAnim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        gameObject.name = playerData.PlayerName;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
    
    private void Update()
    {
        PlayerAnimation();
        PlayerAim();
    }

    #region RWU Callbacks

    private void PlayerMove()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, moveDirection.y);
        moveDirection.Normalize();
        
        if (moveDirection.x != 0 && IsGround())
        {
            myRb.velocity = moveDirection * playerData.PlayerSpeed;
        }
    }

    private void PlayerAnimation()
    {
        if (moveDirection.x != 0 && IsGround())
        {
            myAnim.SetBool("isWalking", true);
        }
        else
        {
            myAnim.SetBool("isWalking", false);
        }
    }

    private void PlayerAim()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        if (Time.timeScale > 0)
        {
            if (mousePosition.x > transform.position.x && isFacingRight)
            {
                PlayerFlip();
            }
            else if (mousePosition.x < transform.position.x && !isFacingRight)
            {
                PlayerFlip();
            }
        }
    }
    
    private void PlayerFlip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundStats.groundCheck.position, 
            groundStats.groundRadius, groundStats.whatIsGround);
    }
    
    public void LaunchImpact(float force)
    {
        myAnim.SetTrigger("Impact");
        Vector2 dir = (UtilsClass.GetMouseWorldPosition() - transform.position).normalized * -1f;
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
    }

    #endregion
    
}
