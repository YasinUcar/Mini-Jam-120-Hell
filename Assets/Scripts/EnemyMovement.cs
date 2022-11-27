using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int returnDelayTime;
    [SerializeField] private float followingDistance;
    private bool rightDirection = false;
    private bool follow = false;
    private bool beingFollowed;
    private Transform MainCharacterFollow;
    private void Start()
    {
        beingFollowed = false;
        StartCoroutine(ChangeDirectionDelayTime());
        MainCharacterFollow = GameObject.FindGameObjectWithTag("AnaKarakter").GetComponent<Transform>();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, MainCharacterFollow.position) > followingDistance)
        {
            beingFollowed = false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            beingFollowed = true;
            transform.position = Vector2.MoveTowards(transform.position, MainCharacterFollow.position, speed * Time.deltaTime);
        }
    }
    IEnumerator ChangeDirectionDelayTime()
    {
        if (beingFollowed == false)
        {
            yield return new WaitForSeconds(returnDelayTime);
            ChangingDirection();
        }
    }
    private void ChangingDirection()
    {
        if (beingFollowed == false)
        {
            rightDirection = !rightDirection;
            Vector3 lookingDirection = transform.localScale;
            lookingDirection.x *= -1;
            transform.localScale = lookingDirection;
            speed *= -1;
            StartCoroutine(ChangeDirectionDelayTime());
        }
    }
}



