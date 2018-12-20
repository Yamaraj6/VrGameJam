using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BraceletCast : MonoBehaviour
{
    public UnityEvent skillToCast;
    
    private void OnTriggerEnter(Collider other) { 
        if (other.CompareTag("StraightFinger"))
        {
            Debug.Log("TriggerEnter" + gameObject.name);
            skillToCast.Invoke();
        }
    }
}
