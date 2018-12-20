using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestroyController : MonoBehaviour, IDestroyable
{
    private bool isDestroyed;
    [SerializeField] private GameObject model;
    [SerializeField] private float destroyDelay;
    
    [Space]
    [SerializeField] private List<DestroyState> states;
    
    private DestroyState currentState;
    private float timer;
    
    private void Start()
    {
        isDestroyed = false;
        states = states.OrderBy(state => state.healthInPercents).ToList();
    }

    private void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                model.SetActive(false);
            }
        }
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
        if (isDestroyed) return;
        isDestroyed = true;
        model.SetActive(false);
    }

    public void DestroyWithDelay()
    {
        if (isDestroyed) return;
        isDestroyed = true;
        timer = destroyDelay;
    }

    public void Reset()
    {
        isDestroyed = false;
        DeactiveAllDestroyStates();
        model.SetActive(true);
        currentState = null;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}
