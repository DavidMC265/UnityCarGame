using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pause.Menu 
{
public class PauseController : MonoBehaviour
{
   public UnityEvent GamePaused;
    public UnityEvent GameResumed;
    private bool _isPaused;

    public Button PauseButton;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTrigger();
        }

    }

    public void PauseTrigger()
    {

        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0;
            GamePaused.Invoke();
        }
        else
        {
            Time.timeScale = 1;
            GameResumed.Invoke();
        }
    }

}

}