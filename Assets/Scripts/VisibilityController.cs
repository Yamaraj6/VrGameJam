using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightGinatHand;
    [SerializeField] private GameObject leftGinatHand;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.Equals(rightHand))
        {
            rightGinatHand.gameObject.SetActive(true);
        }
        if (other.transform.parent.gameObject.Equals(leftHand))
        {
            leftGinatHand.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.transform.parent.gameObject.Equals(rightHand))
        {
            rightGinatHand.gameObject.SetActive(false);
        }
        if (other.transform.parent.gameObject.Equals(leftHand))
        {
            leftGinatHand.gameObject.SetActive(false);
        }
    }
}
