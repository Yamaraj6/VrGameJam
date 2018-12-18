using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform targetPlanet;
    public GameObject enemySpaceshipPrefab;
    public GameObject enemyAlienPrefab;
    public float minRadius;
    public float maxRadius;
    public float offsetZAxis;
    public float speedSpaceship;
    public float frequencySpaceship;
    public float frequencyAlienLanding;
    private float startTime;
    private bool canSpawn;

    public void StartSpawn(){
        targetPlanet = GameController.Instance.targetPlanet;
        canSpawn = true;   
        startTime = Time.time;
    }
    public void StopSpawn(){
        canSpawn = false;   
    }

    private void Update(){
        if (canSpawn && Time.time > startTime + frequencySpaceship){
            startTime = Time.time;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy(){
        Vector3 newPos = RandomCircle(targetPlanet.position, minRadius, maxRadius, offsetZAxis);
        GameObject newEnemy = Instantiate(enemySpaceshipPrefab, newPos, Quaternion.identity);
        newEnemy.GetComponent<SpaceShip>().Initialize(enemyAlienPrefab, speedSpaceship, frequencyAlienLanding);
        GameController.AddSpaceshipToList(newEnemy.transform);
    } 
    private Vector3 RandomCircle(Vector3 center, float minRadius, float maxRadius, float offsetZAxis = 0){
         float ang = Random.value * 360;
         float deltaRadius = Random.Range(minRadius, maxRadius);
         Vector3 pos;
         pos.x = center.x + deltaRadius * Mathf.Sin(ang * Mathf.Deg2Rad) ;
         pos.y = center.y + deltaRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
         pos.z = center.z;
         if (offsetZAxis > 0){
            float distance = Vector3.Distance(center,pos);
            float angle = Random.Range(-offsetZAxis, offsetZAxis);
            pos.z = center.z + angle * (distance / maxRadius);
         }

         return pos;
     }

    void OnDrawGizmosSelected()
    {
        if (targetPlanet){
            Gizmos.color = new Color(1, 1, 0, 0.1F);
            Gizmos.DrawWireSphere(targetPlanet.position, minRadius);
            Gizmos.color = new Color(1, 1, 0, 0.5F);
            Gizmos.DrawWireSphere(targetPlanet.position, maxRadius);
        }
       // Gizmos
    }



}
