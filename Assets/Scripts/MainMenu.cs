using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Menu.Control{
    public class MainMenu : MonoBehaviour
    {
        public void EndlessRunnerStart(){
            SceneManager.LoadScene(1);
        }

        public void QuitApp(){
            Application.Quit();
        }
    }
}