using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashController : MonoBehaviour, ISmashable
{
    [SerializeField] private Animator animator;
    
    public void Smash()
    {
        if (animator)
        {
            animator.SetTrigger("Smash");
        }
    }
}
