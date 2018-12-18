using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplyPlanetGenerator : MonoBehaviour
{
    public GameObject[] planets;
    public GameObject[] towns;
    public int townAmount;



    public Planet CreatePlanet(){
        Transform targetPlanet = GameController.Instance.targetPlanet;
        int index = Random.Range(0, planets.Length);
        GameObject newPlanet = Instantiate(planets[index], targetPlanet.position, Quaternion.identity, targetPlanet);
        Planet planetScript = newPlanet.GetComponent<Planet>();
        if (!planetScript){
            planetScript = newPlanet.AddComponent<Planet>();
        }
        GameObject[] selectedTowns = GetTowns(townAmount);

        planetScript.Initialize(selectedTowns); // #TODO set few random cities
        return planetScript;
    }


    private GameObject[] GetTowns(int amount){
        List<GameObject> newTowns = new List<GameObject>();
        int i = 0;
        while( i < amount ){
            int index = Random.Range(0, towns.Length);
            newTowns.Add(towns[index]);
            i++;
        }
        return newTowns.ToArray();
    }

}
