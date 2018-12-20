using UnityEngine;

public class HandCollisionDetector : MonoBehaviour
{
    [SerializeField] private ADamageHandler damageHandler;
    [SerializeField] private string handColliderTag;
    [Range(0, 25)] [SerializeField] private float damageMultiplier=1;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(handColliderTag))
        {
            Debug.Log("Damage done: " + other.relativeVelocity);
            damageHandler.DealDamage(damageMultiplier * other.relativeVelocity.magnitude);
        }
    }
}
