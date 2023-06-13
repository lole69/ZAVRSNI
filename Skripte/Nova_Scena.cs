using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




    public class Nova_Scena : MonoBehaviour
    {
        public void MoveToScene(int SceneID)
        {
        SceneManager.LoadScene(SceneID);
        }
        public void Quit()
        {
        Application.Quit();
        }
    }
