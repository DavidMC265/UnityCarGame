using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_RaceTrack : MonoBehaviour
{
     public Transform target;
    UnityEngine.Vector3 offset;

    // void Awake(){
    //     transform.position = new UnityEngine.Vector3(-0.181579679f,14.6744995f,-22.3361893f);
    // }
    void Start()
    {
        offset = target.position- transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = target.position - offset;
        Vector3 targetRotationEuler = target.rotation.eulerAngles;
        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationEuler.y, 0f);
        transform.rotation = targetRotation;
    }
}
