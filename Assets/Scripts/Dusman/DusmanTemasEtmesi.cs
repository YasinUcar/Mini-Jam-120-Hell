using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DusmanTemasEtmesi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)   
    {
        if (other.CompareTag("AnaKarakter"))
        {
            Debug.Log("temas var");
        }
    }

}
