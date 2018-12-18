using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Transform targetPlanet;
    private Transform defendObject;
    public float speed;
    public void Initialize(){
        targetPlanet = GameController.Instance.targetPlanet;
        defendObject = GameController.Instance.currentPlanet.transform;
    }

    private void Update(){
       /* if (targetPlanet){
            Vector3 direction = (defendObject.position - transform.position).normalized;
            transform.RotateAround(targetPlanet.position, direction, speed * Time.deltaTime);
       }*/
    }
}
