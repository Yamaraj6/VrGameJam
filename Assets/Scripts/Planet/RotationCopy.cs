using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCopy : MonoBehaviour
{
    public Transform transformCopy;
    
    void Update()
    {
        transformCopy.rotation = transform.rotation;
    }
}
