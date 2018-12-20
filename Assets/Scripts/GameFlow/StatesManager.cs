using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    [System.Serializable]
    public class State
    {
        public GameObject[] elementsToActivate;
        public GameObject[] elementsToDeactivate;
    }

    [SerializeField]
    private State[] states;
    private int currentState;
    
    void Start()
    {
        SetState(0);
    }

    void SetState(int newState)
    {
        Debug.Log("State " + newState);
        currentState = newState;
        foreach (GameObject objectToActivate in states[newState].elementsToActivate)
        {
            objectToActivate.SetActive(true);
        }
        foreach (GameObject objectToDectivate in states[newState].elementsToDeactivate)
        {
            objectToDectivate.SetActive(false);
        }
    }

    public void NextState()
    { 
        if (currentState < states.Length-1)
        {
            SetState(currentState+1);
        }
        else
        {
            SetState(0);
        }
    }

    public void PreviousState()
    {
        if (currentState > 0)
        {
            SetState(currentState-1);
        }
        else
        {
            SetState(states.Length-1);
        }
    }
}
