using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCarWheels : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(3f ,0f ,0f, Space.Self);
    }
}
