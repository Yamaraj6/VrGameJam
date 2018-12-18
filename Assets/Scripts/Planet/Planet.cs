using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
        public Transform defendObject;
        public float radius;

        private void Start(){
                radius = transform.lossyScale.x;
        }

        void OnDrawGizmosSelected()
        {
                Gizmos.color = new Color(0, 0, 1, 1F);
                Gizmos.DrawWireSphere(transform.position, radius);
                Gizmos.color = new Color(1, 0, 0, 0.5F);
                if (defendObject)
                Gizmos.DrawWireCube(defendObject.position, Vector3.one);
        }
}
