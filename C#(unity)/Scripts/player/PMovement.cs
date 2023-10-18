using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour

{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    
    [Header("Layers")]
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask WallLayer;

    [Header("Wall Jump")]
    [SerializeField] private float jumpX;
    [SerializeField] private float jumpY;


    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float HorizontalInput;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
         HorizontalInput = Input.GetAxis("Horizontal");

        
        // flip character based on movement
        if (HorizontalInput > 0.01f)
            transform.localScale =  Vector3.one;

        else if (HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
     


        //set animator parameter

        anim.SetBool("run", HorizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        //walljump
        if (onWall() && HorizontalInput !=0)
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 3;
            body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);
        }
       
    }
    private void Jump()
    {
        
        if (onWall())
            WallJump();
        else
        {
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
                
            }
        }

        

        
    }

    private void WallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * jumpX, jumpY));
        wallJumpCooldown = 0;
            }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, GroundLayer);
        return raycastHit.collider != null;

    }


    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, WallLayer);
        return raycastHit.collider != null;

    }

    public bool canAttack()
    {
        return HorizontalInput == 0 && isGrounded() && !onWall();

    }
}
