using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHandController : MonoBehaviour
{
    [SerializeField] private Transform hologramPlanet;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    
    [SerializeField] private Transform giantPlanet;
    [SerializeField] private Transform rightGinatHand;
    [SerializeField] private Transform leftGinatHand;
    
    private float scale;

    private void Start()
    {
        scale = giantPlanet.localScale.magnitude / hologramPlanet.localScale.magnitude;
    }

    private void Update()
    {
        rightGinatHand.SetPositionAndRotation(
            giantPlanet.position + ((hologramPlanet.transform.position + rightHand.position) * scale),
            rightHand.rotation);
        leftGinatHand.SetPositionAndRotation(
            giantPlanet.position + ((hologramPlanet.transform.position + leftHand.position) * scale),
            leftHand.rotation);
    }
}
