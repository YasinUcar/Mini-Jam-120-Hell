using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lav")
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
