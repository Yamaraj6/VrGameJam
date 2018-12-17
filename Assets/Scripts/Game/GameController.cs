using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance{ get; private set;}
    public Spawner spawner;
    public SimplyPlanetGenerator planetGenerator;

    public Transform targetPlanet;

    private void Awake(){
        if (!Instance){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        spawner.StartSpawn();
        planetGenerator.CreatePlanet();
    }
}
