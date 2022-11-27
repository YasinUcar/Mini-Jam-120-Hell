using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lav : MonoBehaviour
{

    Rigidbody2D LavRb;
    [SerializeField] private float speed;
    void Start()
    {
        LavRb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(bekle());

    }


    void Update()
    {
        LavRb.velocity = Vector2.up * speed * Time.deltaTime;

    }
    IEnumerator bekle()
    {


        for (int i = 0; i < 100; i++)
        {

            yield return new WaitForSeconds(2f);
            speed *= 1.02f;
        }
    }

}



