using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognition : MonoBehaviour
{
    public Collider fistCollider;
    void Update()
    {
        Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) );
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >0.7f && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >0.7f)
        {
            fistCollider.enabled = true;
        }
        else
        {
            fistCollider.enabled = false;
        }
    }
}
