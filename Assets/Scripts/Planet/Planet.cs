using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{      
        [System.Serializable]
        public class TownCoordinate{
                public Transform coordinate;
                public bool isUsed;
        }
        public TownCoordinate[] townCoordinates;
        public List<Transform> defendObjects = new List<Transform>();
        public float radius;

        public void Initialize(GameObject[] townPrefabs){
                for (int i = 0; i <townCoordinates.Length; i++){
                        if (i < townPrefabs.Length){
                                Transform coordinate = GetRandomCoordinate();
                                GameObject newTown = Instantiate(townPrefabs[ i ], coordinate.position, coordinate.rotation, transform);
                                defendObjects.Add( newTown.transform );
                        }
                }
        }

        private void Start(){
                radius = transform.lossyScale.x;
        }

        private Transform GetRandomCoordinate(){
                int tries = 0;
                // try 10 time to random coord
                while(tries < 10){
                        int index = Random.Range(0,townCoordinates.Length);
                        if (!townCoordinates[index].isUsed){
                                townCoordinates[index].isUsed = true;
                                return townCoordinates[index].coordinate;
                        }
                        tries++;
                }
                // else take first not used coord
                foreach(TownCoordinate obj in townCoordinates){
                        if (!obj.isUsed){
                                obj.isUsed = true;
                                return obj.coordinate;
                        }
                }
                // else take first from array
                if (townCoordinates.Length > 0)
                        return townCoordinates[0].coordinate;
                else
                        return null;
        }

        public Transform GetNearestTwon(Transform enemy){
                Transform nearestTown = null;
                float nearestDistance = float.PositiveInfinity;
                foreach(TownCoordinate obj in townCoordinates){
                        if (obj.isUsed){
                                float newDistance = Vector3.Distance(obj.coordinate.position, enemy.position);
                                if ( newDistance < nearestDistance){
                                        nearestTown = obj.coordinate;
                                       nearestDistance = newDistance; 
                                }
                        }
                }
                return nearestTown;
        }
        void OnDrawGizmosSelected()
        {
                Gizmos.color = new Color(0, 0, 1, 1F);
                Gizmos.DrawWireSphere(transform.position, radius);
                if (townCoordinates != null){
                        foreach(TownCoordinate obj in townCoordinates){
                                if (obj.coordinate){
                                        if (obj.isUsed){
                                                Gizmos.color = new Color(1, 0, 0, 0.3F);
                                        }else{
                                                Gizmos.color = new Color(0, 1, 0, 0.75F);
                                        }
                                        Gizmos.DrawWireCube(obj.coordinate.position, Vector3.one * 0.35f);
                                }
                        }
                }
        }
}
