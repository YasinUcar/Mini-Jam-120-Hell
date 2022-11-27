using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    [Header("Chacter Speeds")]
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    
    Rigidbody2D rig2d;
   

    CapsuleCollider2D myFeedCollider;
   
    private void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        myFeedCollider = GetComponent<CapsuleCollider2D>();
        anim = gameObject.GetComponent<Animator>();
     
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();
       
    }
  
    void Run()
    {
    
        
         // rig2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig2d.velocity.y);

            rig2d.velocity=Vector2.right*speed*Time.deltaTime;
           
    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rig2d.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rig2d.velocity.x), 1);
            anim.SetTrigger("run");
        }
    }
    void Jump()
    {
        if (!myFeedCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            rig2d.velocity = new Vector2(rig2d.velocity.x, jumpSpeed);
            anim.SetTrigger("jump");
        }
       
    }
}
