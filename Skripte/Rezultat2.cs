using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rezultat2 : MonoBehaviour
{

    [SerializeField] private Text natpis1;


    public int rezultat;
    void Start()
    {
        rezultat = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.GetComponent<Kontroliranjelopte>() != null)
        {
            rezultat++;
            natpis1.text = rezultat.ToString();
            col.gameObject.GetComponent<Kontroliranjelopte>().ResetirajLoptu();
        }
    }

}
