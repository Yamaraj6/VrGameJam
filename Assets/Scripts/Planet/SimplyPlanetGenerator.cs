using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplyPlanetGenerator : MonoBehaviour
{
    public GameObject[] planets;



    public void CreatePlanet(){
        Transform targetPlanet = GameController.Instance.targetPlanet;
        int index = Random.Range(0, planets.Length);
        GameObject newPlanet = Instantiate(planets[index], targetPlanet.position, Quaternion.identity);
        newPlanet.transform.SetParent(targetPlanet);
    }
}
