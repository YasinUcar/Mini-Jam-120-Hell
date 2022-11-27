using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayGame : MonoBehaviour
{

    [SerializeField] GameObject startingGameCanvas;


    private void Start()
    {


    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            this.gameObject.SetActive(false);
            startingGameCanvas.SetActive(true);

        }
    }
}
