using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraScript : MonoBehaviour
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
    }
}
