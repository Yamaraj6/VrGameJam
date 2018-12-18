using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramController : MonoBehaviour
{
    [SerializeField] private Transform giantPlanet;
    [SerializeField] private Transform hologramPlanet;

    [SerializeField] private Transform hologramParent;
    [SerializeField] private GameObject hologramSpaceship;
    [SerializeField] private GameObject addHologramEffect;
    [SerializeField] private GameObject destroyHologramEffect;

    private List<Transform> spaceships;
    private List<Transform> aliens;

    private List<Transform> holoSpaceships;
    private List<Transform> holoAliens;

    private float scale;

    public static HologramController Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        scale = hologramPlanet.localScale.magnitude/giantPlanet.localScale.magnitude ;
        spaceships = GameController.GetAllSpaceships();
        holoSpaceships=new List<Transform>();
        holoAliens=new List<Transform>();
    }

    void Update()
    {
        UpdateHologramsPosition();
    }

    public void AddHologram()
    {
        var holoPostion = hologramPlanet.position -giantPlanet.position*scale+
                          ((spaceships[spaceships.Count - 1].transform.position +
                            spaceships[spaceships.Count - 1].transform.position) * scale);
        var holoRotation = spaceships[spaceships.Count - 1].transform.rotation;
        holoSpaceships.Add(Instantiate(hologramSpaceship.transform, holoPostion, holoRotation, hologramParent));
        //addHologramEffect
    }

    public void DestroyHologram(Transform hologramToDestroy)
    {
        holoSpaceships.Remove(hologramToDestroy);
        // removeHoloEffect
    }

    public void UpdateHologramsPosition()
    {
        for (int i = 0; i < spaceships.Count; i++)
        {
            var holoPostion = hologramPlanet.position +
                              ((spaceships[i].transform.position - giantPlanet.position) * scale);
            var holoRotation = spaceships[i].transform.rotation;
            holoSpaceships[i].transform.SetPositionAndRotation(
                holoPostion, holoRotation);
        }
    }
}