using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DusmanHareket : MonoBehaviour
{
    public int speed;
    public int DonusGecikmeSuresi;
    bool SagYon = false;

    public bool takipEt = false;

    bool takipEdiliyor;

    [SerializeField] float takipEtmeMesafesi;



    private Transform AnaKarakterTakip;
    private void Start()
    {
        takipEdiliyor = false;
        StartCoroutine(YonDegistirmeGecikkmeSuresi());


        AnaKarakterTakip = GameObject.FindGameObjectWithTag("AnaKarakter").GetComponent<Transform>();
    }

    private void Update()
    {
        Hareket();
       
    }
  
    void Hareket()
    {
        if (Vector2.Distance(transform.position, AnaKarakterTakip.position) > takipEtmeMesafesi)
        {
            takipEdiliyor=false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        else 
        {
          takipEdiliyor=true;

            transform.position = Vector2.MoveTowards(transform.position, AnaKarakterTakip.position, speed * Time.deltaTime);

            Debug.Log("foksiyon �al��");
        }
    }

    IEnumerator YonDegistirmeGecikkmeSuresi()
    {
        if (takipEdiliyor == false)
        {
            yield return new WaitForSeconds(DonusGecikmeSuresi);
            YonDegistirme();
        }
           
        
    }
    private void YonDegistirme()
    {
        if (takipEdiliyor == false)
        {
            SagYon = !SagYon;
            Vector3 bakisYonu = transform.localScale;
            bakisYonu.x *= -1;
            transform.localScale = bakisYonu;
            speed *= -1;
            StartCoroutine(YonDegistirmeGecikkmeSuresi());

        }

    }
}

  

