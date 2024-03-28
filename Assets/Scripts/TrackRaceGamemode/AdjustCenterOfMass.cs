using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AdjustCenterOfMass : MonoBehaviour
{
  [SerializeField] UnityEngine.Vector3 centerOfMass = UnityEngine.Vector3.zero;
  private void Start(){
    GetComponent<Rigidbody>().centerOfMass += centerOfMass;

  }

  private void  OnDrawGizmosSelected()
  {
    Gizmos.color = Color.green;

    var currentCenterOfMass = this.GetComponent<Rigidbody>().worldCenterOfMass;
    Gizmos.DrawSphere(currentCenterOfMass + centerOfMass, 0.125f);
  }
}
