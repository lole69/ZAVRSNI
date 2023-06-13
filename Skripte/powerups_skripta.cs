using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups_skripta : MonoBehaviour
{


    [SerializeField] GameObject[] moci;
    [SerializeField] float max;
    [SerializeField] float min;




    void Start()
    {
        StartCoroutine(Stvaranje());
    }
    IEnumerator Stvaranje()
    {
        while(true){
           // yield return new WaitForSeconds(15f);
            yield return new WaitForSeconds(5f);
            var randx = Random.Range(min, max);
            var randy = Random.Range(-4.6f, 4.6f);
            var position = new Vector3(randx, randy);
            GameObject gameObject = Instantiate(moci[Random.Range(0, moci.Length)], position, Quaternion.identity);
            Destroy(gameObject, 15f);
        }
    }
    void Update()
    {
            
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("crveni"))
        {
            Debug.Log("Collision Detected");
        }
        else
            Debug.Log("Collision Detected");

        /*
         
        if (collision.gameObject.CompareTag("zeleni"))
        {
            Debug.Log("Collision Detected");
        }
        if (collision.gameObject.CompareTag("zuti"))
        {
            Debug.Log("Collision Detected");
        }*/
    }

}
