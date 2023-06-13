using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontroliranjelopte : MonoBehaviour
{


    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float speedIncrease = 1f;
    [SerializeField] private float startingSpeed = 7f;
    [SerializeField] private float thrust = 2f;


    private Rigidbody2D rb;
    private float currentSpeed;
    // private int hitCount = 0;
    public int rand;
    public string zadnji = "";

    public int r1velicina = 0;
    public int r2velicina = 0;
    public int velicinalopte = 0;


    public float minVelicina = 1f;
    public float maxVelicina = 5f;
    [SerializeField] public GameObject prefabObjekt;
    public float minX = -7 , maxX=7, minY=-4, maxY=4;  



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        currentSpeed = startingSpeed;
        ResetirajLoptu();
    }
    IEnumerator DelayedFunction(float delayTime)
    {
        float timer = 0f;
        while (timer < delayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        thrust = Mathf.Clamp(thrust - 0.1f, 1f, 10f);
        float randomAngle = Random.Range(-45, 45) + (Random.Range(0, 2) * 180);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
        rb.AddForce(direction * thrust, ForceMode2D.Impulse);
    }

    public void ResetirajLoptu()
    {
        foreach (GameObject objekt in GameObject.FindGameObjectsWithTag("Prepreka"))
        {
            Destroy(objekt);
        }
        GameObject vanjskiObjekt1 = GameObject.Find("Reket1");
        vanjskiObjekt1.transform.localScale = new Vector3(1, 1, 1);
        GameObject vanjskiObjekt2 = GameObject.Find("Reket2");
        vanjskiObjekt2.transform.localScale = new Vector3(1, 1, 1);
        GameObject novaVelicina = GameObject.Find("Lopta");
        novaVelicina.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        zadnji = "nitko";
        r1velicina = 0;
        r2velicina = 0;
        velicinalopte = 0;
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        currentSpeed = startingSpeed;
        StartCoroutine(DelayedFunction(2f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CapsuleCollider2D>() != null)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + speedIncrease, minSpeed, 100f);
            rb.velocity = rb.velocity.normalized * currentSpeed;

            if (collision.gameObject.CompareTag("Reket1"))
            {
                zadnji = "Reket1";
                float yCollision = collision.contacts[0].point.y;
                float yCenter = collision.collider.bounds.center.y;
                float yDiff = yCollision - yCenter;

                float xDirection = (transform.position.x < collision.gameObject.transform.position.x) ? -1 : 1;

                if (yDiff < 0)
                {
                    rb.velocity = new Vector2(xDirection, -1).normalized * Mathf.Abs(rb.velocity.magnitude);
                }
                else
                {
                    rb.velocity = new Vector2(xDirection, 1).normalized * Mathf.Abs(rb.velocity.magnitude);
                }
            }
            if (collision.gameObject.CompareTag("Reket2"))
            {
                zadnji = "Reket2";
                float yCollision = collision.contacts[0].point.y;
                float yCenter = collision.collider.bounds.center.y;
                float yDiff = yCollision - yCenter;

                float xDirection = (transform.position.x < collision.gameObject.transform.position.x) ? -1 : 1;

                if (yDiff < 0)
                {
                    rb.velocity = new Vector2(xDirection, -1).normalized * Mathf.Abs(rb.velocity.magnitude);
                }
                else
                {
                    rb.velocity = new Vector2(xDirection, 1).normalized * Mathf.Abs(rb.velocity.magnitude);
                }
            }

        }
     
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zeleni"))
        {
            Destroy(collision.gameObject);

            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                rb.velocity = rb.velocity.normalized * 90f;
            }
            if(rand==1)
            {
                GameObject vanjskiObjekt = GameObject.Find(zadnji);
                if (zadnji == "Reket1" && r1velicina == 1)
                {
                    rb.velocity = rb.velocity.normalized * 90f;

                }
                if (zadnji == "Reket1" && r1velicina == 0)
                {
                    vanjskiObjekt.transform.localScale = new Vector3(2, 2, 2);
                    r1velicina = 1;
                }
                if (zadnji == "Reket2" && r2velicina == 1)
                {
                    rb.velocity = rb.velocity.normalized * 90f;

                }
                if (zadnji == "Reket2" && r2velicina == 0)
                {
                    vanjskiObjekt.transform.localScale = new Vector3(2, 2, 2);
                    r2velicina = 1;
                }
                if (zadnji == "nitko")
                {
                    rb.velocity = rb.velocity.normalized * 90f;
                }

            }

           

        }
        if (collision.CompareTag("zuti"))
        {
            Destroy(collision.gameObject);

            rand = Random.Range(0, 2);

            if (rand == 1 || velicinalopte == 1)
            {

                float nasumicniX = Random.Range(minX, maxX);
                float nasumicniY = Random.Range(minY, maxY);

                float nasumicnaVelicina = Random.Range(1.5f, 3f);
                GameObject noviObjekt = Instantiate(prefabObjekt, new Vector3(nasumicniX, nasumicniY, 0), Quaternion.identity);
                noviObjekt.transform.localScale = new Vector3(nasumicnaVelicina, nasumicnaVelicina, nasumicnaVelicina);
                noviObjekt.tag = "Prepreka";

            }
            if (rand == 0 && velicinalopte!=1)
            {
                GameObject novaVelicina = GameObject.Find("Lopta");
                novaVelicina.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                velicinalopte++;
            }
        }

        if (collision.CompareTag("crveni"))
        {

            Destroy(collision.gameObject);

            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                GameObject novaVelicina4 = GameObject.Find("Lopta");
                novaVelicina4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            }
            if (rand == 1)
            {
                GameObject vanjskiObjekt = GameObject.Find(zadnji);
                if (zadnji == "Reket1" && r1velicina == -1)
                {
                    GameObject novaVelicina4 = GameObject.Find("Lopta");
                    novaVelicina4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                if (zadnji == "Reket1" && r1velicina == 0)
                {
                    vanjskiObjekt.transform.localScale = new Vector3(0.5f, 0.5f, 10.5f);
                    r1velicina = -1;
                }
                if (zadnji == "Reket2" && r2velicina == -1)
                {
                    GameObject novaVelicina4 = GameObject.Find("Lopta");
                    novaVelicina4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                if (zadnji == "Reket2" && r2velicina == 0)
                {
                    vanjskiObjekt.transform.localScale = new Vector3(0.5f, 0.5f, 10.5f);
                    r2velicina = -1;
                }
                if (zadnji == "nitko")
                {
                    GameObject novaVelicina4 = GameObject.Find("Lopta");
                    novaVelicina4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }


            }
        }


    }




}
