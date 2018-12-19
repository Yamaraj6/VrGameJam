using System;
using UnityEngine;

public class GestureRecognition : MonoBehaviour
{
    [SerializeField] private Hand hand;
    [SerializeField]private Collider fistCollider;
    [SerializeField]private Collider straightFingerCollider;
    [SerializeField]private Collider openHandCollider;
    private Gesture actualGesture;
   
    private OVRInput.Axis1D indexTrigger;
    private OVRInput.Axis1D handTrigger;
    
    private void Awake()
    {
        switch (hand)
        {
            case Hand.Left:
                indexTrigger = OVRInput.Axis1D.PrimaryIndexTrigger;
                handTrigger = OVRInput.Axis1D.PrimaryHandTrigger;
                break;
            case Hand.Right:
                indexTrigger = OVRInput.Axis1D.SecondaryIndexTrigger;
                handTrigger = OVRInput.Axis1D.SecondaryHandTrigger;
                break;
        }
    }

    void Update()
    {
        UpdateGesture();
        Debug.Log(actualGesture);
    }

    private void UpdateGesture()
    {
        if (OVRInput.Get(handTrigger) > 0.9f)
        {
            if (OVRInput.Get(indexTrigger) > 0.9f)
            {
                ActualizeGesture(Gesture.Fist);
            }
            else
            {
                ActualizeGesture(Gesture.StraightFinger);
            }
        }
        else
        {
            ActualizeGesture(Gesture.OpenHand);
        }
    }

    private void ActualizeGesture(Gesture gesture)
    {
        if (actualGesture == gesture) return;
        actualGesture = gesture;
        switch (gesture)
        {
            case Gesture.Fist:
                fistCollider.enabled = true;
                straightFingerCollider.enabled = false;
                openHandCollider.enabled = false;
                break;
            case Gesture.StraightFinger:
                fistCollider.enabled = false;
                straightFingerCollider.enabled = true;
                openHandCollider.enabled = false;
                break;
            case Gesture.OpenHand:
                fistCollider.enabled = false;
                straightFingerCollider.enabled = false;
                openHandCollider.enabled = true;
                break;
        }

    }

    public Gesture GetActualGesture()
    {
        return actualGesture;
    }
}

public enum Gesture
{
    Fist,
    StraightFinger,
    OpenHand
}

public enum Hand
{
    Left,
    Right
}
