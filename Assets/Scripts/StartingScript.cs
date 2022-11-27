using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScript : MonoBehaviour
{

    [SerializeField] GameObject gameOverCanvas, lavObject;

    PlayerController player;


    private void Awake()
    {
        gameOverCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Start()
    {


        lavObject.SetActive(false);
        player.enabled = false;
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.enabled = true;
            lavObject.SetActive(true);
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
        }

    }
}
