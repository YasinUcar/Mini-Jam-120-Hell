using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    
=======
>>>>>>> 07347639b5ee00bd01382269973404b1fe0547e1
    [Header("Chacter Speeds")]
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Rigidbody2D rig2d;
    CapsuleCollider2D myFeedCollider;
    private void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        myFeedCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        Jump();

    }
    void Run()
    {
        rig2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig2d.velocity.y);

    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rig2d.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rig2d.velocity.x), 1);
        }
    }
    void Jump()
    {
        if (!myFeedCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
            rig2d.velocity = new Vector2(rig2d.velocity.x, jumpSpeed);
    }
<<<<<<< HEAD
    
=======
>>>>>>> 07347639b5ee00bd01382269973404b1fe0547e1
}
