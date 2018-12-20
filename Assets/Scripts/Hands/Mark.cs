using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark :MonoBehaviour
{
    [SerializeField]
    private SmashDetector smashDetector;
    [SerializeField] private string handColliderTag;
    
    [HideInInspector] public Collider collider;
    [HideInInspector] public bool isChecked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(handColliderTag))
        {
            smashDetector.Check(this);
        }
    }
}