using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tiles.Runner;
using Pause.Menu;
using Score.Manager;

namespace Player.Runner {
public class Player : MonoBehaviour
{

    public float speed;
    public float speedTurn;
    public float horizontalMov;
    public float sidewaysForce = 50f;
    public float MaxRotationY = 45f;
    public float MinRotationY = -45f;

    private float SpeedIncrease = 20.0f;

    private float FirstSpeedTimer = 15.0f;
    private float SecondSpeedTimer = 30.0f;
    private float ThirdSpeedTimer = 45.0f;


    private Transform localTrans;
    [SerializeField] GameObject canva;
    [SerializeField] GameObject Pausebutton;
    [SerializeField] GameObject RestartButton;

    public Tiles.Runner.GroundSpawner disableGroundSpawner;


    void Awake()
    {
        Invoke("FirstSpeedIncrease", FirstSpeedTimer);
        Invoke("SecondSpeedIncrease", SecondSpeedTimer);
        Invoke("ThirdSpeedIncrease", ThirdSpeedTimer);
    }

    void Start()
    {
        canva.SetActive(true);
        Pausebutton.SetActive(true);
        RestartButton.SetActive(false);
        localTrans = GetComponent<Transform>();

    }

    void FixedUpdate()
    {
        float horizontalMov = Input.GetAxis("Horizontal");
        
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
         transform.Rotate(Vector3.up *horizontalMov * Time.deltaTime * speedTurn);

       LimitRot();
       
    }

    private void LimitRot()
    {
        Vector3 playerEulerAngles =localTrans.rotation.eulerAngles;

        playerEulerAngles.y = (playerEulerAngles.y > 180)? playerEulerAngles.y- 360 : playerEulerAngles.y;
        playerEulerAngles.y = Math.Clamp(playerEulerAngles.y, MinRotationY, MaxRotationY);

        localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ObstacleTag")
        {
            print("Collision Detected");
            IsDead();
            Pausebutton.SetActive(false);
            RestartButton.SetActive(true);
            
        }

        if(collision.gameObject.tag == "CoinTag")
        {
            print("Coin picked up");
            Destroy(collision.gameObject);
            ScoreManager.ScoreCount += 1;
        }
    }

        //Executing the following after the player is dead 
        public bool IsDead()
        {
            print("Deaaaaaad");
            enabled = false;
            if (disableGroundSpawner!= null){
                print("Worked Ground disabled");
                disableGroundSpawner.enabled = false;
            }
            else{print("Not disabling");};

            return true;
        }

        //Speed Increments after timer finishes 
        public void FirstSpeedIncrease(){
            speed += SpeedIncrease;
            speedTurn += SpeedIncrease;
            print("First Speed Increase!");
        }

        public void SecondSpeedIncrease(){
            speed += SpeedIncrease;
            speedTurn += SpeedIncrease;
            print("Second Speed Increase");
        }

        public void ThirdSpeedIncrease(){
            speed += SpeedIncrease;
            speedTurn += SpeedIncrease;
            print("Third Speed Increase");
        }
    }


}


