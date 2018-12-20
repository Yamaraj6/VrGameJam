using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(IDamageHandler))]
public class HandCollisionDetector : MonoBehaviour
{
    [SerializeField] private string handColliderTag;
    [Range(0, 25)] [SerializeField] private float damageMultiplier=1;
    private IDamageHandler damageHandler;
    
    
    private void Awake()
    {
        damageHandler = GetComponent<IDamageHandler>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(handColliderTag))
        {
            Debug.Log("Damage done: "+other.relativeVelocity);
            damageHandler.GetDamage(damageMultiplier*other.relativeVelocity.magnitude);
        }
    }
}
