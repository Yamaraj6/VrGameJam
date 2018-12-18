using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private Transform targetPlanet;
    private Transform defendObject;
    private float speed;
    private Vector3 wayPoint;
        
    private Vector3 axis;
    private float radius;

    private NavMeshAgent navMeshAgent;
    public void Initialize(){
        targetPlanet = GameController.Instance.targetPlanet;
        defendObject = GameController.Instance.currentPlanet.GetNearestTwon(transform);
        radius = GameController.Instance.currentPlanet.radius;
        speed = GameController.Instance.spawner.speedAlien;
       // wayPoint = defendObject.position; //Random.onUnitSphere * radius + targetPlanet.position;
    }

    private void Update(){ 
        if((transform.position - wayPoint).sqrMagnitude > 5){
            GetDirectionTo();
        }
 
    // do the rotation
    transform.RotateAround(targetPlanet.position, axis , speed * Time.deltaTime);
    // just for reference...
    //Debug.DrawLine(wayPoint, targetPlanet.position, Color.red);
    }

    private void GetDirectionTo()
    {
    
    
        // so we know..
        var toShip = transform.position - targetPlanet.position;
        var toWayPoint = defendObject.position - targetPlanet.position;
    
        // get the axis we are going to be rotating around
        axis = Vector3.Cross(toShip, toWayPoint);
    
        // now lets get the heading
        var forwardDirection = Vector3.Cross(axis, toShip);
        // lets debug the lines...
        //Debug.DrawLine(transform.position, transform.position + forwardDirection, Color.yellow, 1);
    
        // now, lets look at that heading
        transform.LookAt(transform.position + forwardDirection, toShip);
    }


}
