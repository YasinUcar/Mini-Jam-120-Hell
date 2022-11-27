using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    Rigidbody2D rig2d;
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig2d.velocity = new Vector2(Input.GetAxis("Horizontal") * 5f, rig2d.velocity.y);
    }
}
