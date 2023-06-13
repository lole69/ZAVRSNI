using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontroliranjeReketa2 : MonoBehaviour
{
    Vector3 tempPos;
    // private Rigidbody2D rb;
    public GameObject primljeno;


    /*
    private void Pomaci()
    {

        foreach (Touch dodir in Input.touches)
        {


            Vector3 pozicijadodira = Camera.main.ScreenToWorldPoint(dodir.position);
            Vector2 myPositon = rb.position;

            if (Mathf.Abs(pozicijadodira.x - myPositon.x) <= 2)
            {


                myPositon.y = Mathf.Lerp(myPositon.y, pozicijadodira.y, 10);
                myPositon.y = Mathf.Clamp(myPositon.y, -3.7f, 3.7f);
                rb.position = myPositon;
            }
        }
    }
    */
    public float yMin = -5f;
    public float yMax = 5f;
    private Collider2D myCollider;
    private float yMinClamp;
    private float yMaxClamp;

    void Start()
    {
        primljeno = FindObjectOfType<npr>().gameObject;


        //  rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        float objectHeight = myCollider.bounds.size.y;
        yMinClamp = yMin + objectHeight / 2f;
        yMaxClamp = yMax - objectHeight / 2f;
    }

    void Update()
    {

        string msg = primljeno.GetComponent<npr>().received_message;
        float y = Mathf.Clamp(transform.position.y, yMinClamp, yMaxClamp);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        if (msg.Contains("g2"))
        {
            Debug.Log("pomakni gore");
            transform.Translate(Vector2.up * 0.2f);
        }
        else if (msg.Contains("d2"))
        {
            transform.Translate(Vector2.down * 0.2f);
        }
        else if (msg.ToString() == "0")
        {
        }

        float objectHeight = myCollider.bounds.size.y;
        yMinClamp = yMin + objectHeight / 2f;
        yMaxClamp = yMax - objectHeight / 2f;


    }

}
