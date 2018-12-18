using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour, IDestroyable
{
    private bool isDestroyed;
    [SerializeField] private List<DestroyState> states;
    
    private void Start()
    {
        isDestroyed = false;
    }

    public void SetDestroyState(float currentHealthInPercents)
    {
        foreach (var destroyState in states)
        {
            if (currentHealthInPercents<destroyState.healthInPercents)
            {
                destroyState.state.SetActive(true);
            }
        }
        
        if (currentHealthInPercents <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        isDestroyed = true;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}
