using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(IDamageHandler))]
public class HandCollisionDetector : MonoBehaviour
{
    [SerializeField] private string handColliderTag;
    private IDamageHandler damageHandler;
    
    private void Awake()
    {
        damageHandler = GetComponent<IDamageHandler>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(handColliderTag))
        {
            Debug.Log(other.relativeVelocity.magnitude);
            Debug.Log(other.relativeVelocity);
            damageHandler.GetDamage(other.relativeVelocity.magnitude);
        }
    }
}
