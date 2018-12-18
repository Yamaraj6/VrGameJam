using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance{ get; private set;}
    public Planet currentPlanet {get; private set;}
    public Spawner spawner;
    public SimplyPlanetGenerator planetGenerator;

    public Transform targetPlanet;

    private List<Transform> allSpaceships = new List<Transform>();
    private List<Transform> allAliens = new List<Transform>();

    private void Awake(){
        if (!Instance){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    private void Start(){
        spawner.StartSpawn();
        currentPlanet = planetGenerator.CreatePlanet();
    }

# region Static Methods
    public static void AddAlienToList(Transform newAlien){
        GameController.Instance.allAliens.Add(newAlien);
    }
    public static void AddSpaceshipToList(Transform newSpaceship){
        GameController.Instance.allSpaceships.Add(newSpaceship);
        HologramManager.Instance?.AddHologram(newSpaceship);
    }
    public static void RemoveSpaceshipFromList(Transform spaceship){
        GameController.Instance.allSpaceships.Remove(spaceship);
        HologramManager.Instance?.DestroyHologram(spaceship);
    }
    public static void RemoveAlienFromList(Transform alien){
        GameController.Instance.allAliens.Remove(alien);
    }
    public static List<Transform> GetAllSpaceships(){
        return GameController.Instance.allSpaceships;
    }
    public static List<Transform> GetAllAliens(){
        return GameController.Instance.allAliens;
    }
#endregion
}
