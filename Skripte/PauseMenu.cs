using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameObject myElement6 = GameObject.Find("Lopta");
        myElement6.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f); // transparentan


    }
    public void Resume()
    {
        GameObject myElement6 = GameObject.Find("Lopta");
        myElement6.GetComponent<Renderer>().material.color = Color.white; // bijela boja
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        /*
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        GameObject myElement = GameObject.Find("Lopta");
        myElement.GetComponent<Kontroliranjelopte>().ResetirajLoptu();
        GameObject myElement4 = GameObject.Find("Reket1");
        Vector3 newPosition1 = myElement4.transform.position;
        newPosition1.y = 0f; 
        myElement4.transform.position = newPosition1;
        
        GameObject myElement5 = GameObject.Find("Reket2");
        Vector3 newPosition2 = myElement5.transform.position;
        newPosition2.y = 0f;
        myElement5.transform.position = newPosition2;
        myElement.GetComponent<Renderer>().material.color = Color.white; // bijela boja

        GameObject myElement7 = GameObject.Find("desnagranica");
        myElement7.GetComponent<Rezultat>().Resetirajrezu();

        */
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        



    }

    public void Pocetna(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);

    }
}
