using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles.Runner;
using Pause.Menu;
using Score.Manager;

public class RaceTrackPlayerControl : MonoBehaviour
{

    public float speed;
    public float speedTurn; 

    void FixedUpdate()
    {
        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");
        
         transform.Translate(Vector3.forward * Time.deltaTime * speed *verticalMov);
         transform.Rotate(Vector3.up *horizontalMov  * speedTurn);

       
    }

}
