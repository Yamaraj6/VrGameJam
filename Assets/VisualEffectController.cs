using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VisualEffectController : MonoBehaviour
{
    public VisualEffect ve;
    public Transform leftHand;
    public Transform rightHand;
    
    private void Update()
    {
        ve.transform.SetPositionAndRotation((leftHand.position+rightHand.position)/2f,Quaternion.identity);
        ve.SetFloat("Radius", Vector3.Distance(leftHand.position,rightHand.position)/5f);
    }
}
