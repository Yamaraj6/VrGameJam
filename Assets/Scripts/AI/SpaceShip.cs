using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    private GameObject enemyAlienPrefab;
    private Transform targetPlanet;
    private float startTime;
    private float frequencyAlienLanding;
    private bool canLanding;
    private Vector3 landingPosition;

    // fly variables
    private float speed;
	private Vector3 startPosition;
	private Vector3 endPosition;
    private float journeyLength;

    

    public void Initialize(GameObject enemyAlienPrefab, float speed, float frequencyAlienLanding){
        this.enemyAlienPrefab = enemyAlienPrefab;
        this.speed = speed;
        this.frequencyAlienLanding = frequencyAlienLanding;
        targetPlanet = GameController.Instance.targetPlanet;
        startPosition = transform.position;
        endPosition = targetPlanet.position;
        journeyLength = Vector3.Distance(transform.position, targetPlanet.position);
        startTime = Time.time;
    }
    
    private void OnTriggerEnter(Collider collider){
        if (collider.CompareTag("PlanetAtmosphere")){
            transform.SetParent(targetPlanet);
            StartLanding();
        }
    }

    private void Update(){
        if (canLanding){
            if (Time.time > startTime + frequencyAlienLanding){
                startTime = Time.time;
                CreateAlien();
            }
        }else{
            MoveToPlanet();
        }

    }

    private void MoveToPlanet(){
		float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
    }
    private void StartLanding(){
        // rotate ship face to planet
        transform.LookAt(targetPlanet,Vector3.up);
        transform.Rotate(Vector3.left * 90.0f, Space.Self);
        // start animation landing
        // animator.SetTrigger("Landing");
        // create aliens
        if(PrepareToLanding()){
            canLanding = true;
            startTime = Time.time;
        }
    }

    private bool PrepareToLanding(){
        // get planet surface point where aliens will be spawn
        RaycastHit[] hits;
        Vector3 direction = (targetPlanet.position - transform.position).normalized;
        Debug.DrawRay(transform.position,direction * 10.0f, Color.red,5);
        hits = Physics.RaycastAll(transform.position, direction, float.PositiveInfinity);

        foreach(RaycastHit obj in hits){
            if (obj.collider.CompareTag("Planet")){
                landingPosition = obj.point;
                return true;
            }
        }
        return false;
    }

    private void CreateAlien(){
        GameObject newAlien = Instantiate(enemyAlienPrefab,landingPosition,Quaternion.identity);
        newAlien.transform.SetParent(targetPlanet);
        newAlien.GetComponent<Alien>().Initialize();    
        GameController.AddAlienToList(newAlien.transform);
    }


}
