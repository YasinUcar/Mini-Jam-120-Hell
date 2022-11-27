using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    [Header("Chacter Speeds")]
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    [SerializeField] private float climbingSpeed;
    private bool Climbable;
    Rigidbody2D rig2d;


    CapsuleCollider2D myFeedCollider;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
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
        Climbing_();
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
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("idle");
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
    private void Climbing_()
    {
        if (Climbable)
        {
            rig2d.gravityScale = 0;
            rig2d.velocity = Vector2.up * climbingSpeed;
            Debug.Log("merdivene ��kmaya ba�la");
        }
        else
        {
            rig2d.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Merdiven"))
        {
            Climbable = true;
        }
        Debug.Log("merdivene ��kmaya ba�la");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Merdiven"))
        {
            Climbable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Merdiven"))
        {
            Climbable = false;
        }
    }
}
