using System;
using UnityEngine;

[Serializable]
public class DestroyState
{
    [Range(0, 100)] public float healthInPercents;
    public GameObject state;
}