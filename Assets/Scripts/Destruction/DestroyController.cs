using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyController : MonoBehaviour, IDestroyable
{
    private bool isDestroyed;
    [SerializeField] private GameObject spaceshipModel;
    [SerializeField] private List<DestroyState> states;
    private DestroyState currentState;
    
    private void Start()
    {
        isDestroyed = false;
        states = states.OrderBy(state => state.healthInPercents).ToList();
    }

    public void UpdateDestroyState(float currentHealthInPercents)
    {
        foreach (var destroyState in states)
        {
            if (currentHealthInPercents <= destroyState.healthInPercents)
            {
                if (currentState != destroyState)
                {
                    currentState = destroyState;
                    DeactiveAllDestroyStates();
                    destroyState.state.SetActive(true);
                    if (currentHealthInPercents <= 0)
                    {
                        Destroy();
                    }
                }
                return;
            }
        }
    }

    private void DeactiveAllDestroyStates()
    {
        foreach (var destroyState in states)
        {
            destroyState.state.SetActive(false);
        }
    }

    public void Destroy()
    {
        isDestroyed = true;
        spaceshipModel.SetActive(false);
    }

    public void Reset()
    {
        isDestroyed = false;
        DeactiveAllDestroyStates();
        spaceshipModel.SetActive(true);
        currentState = null;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}
