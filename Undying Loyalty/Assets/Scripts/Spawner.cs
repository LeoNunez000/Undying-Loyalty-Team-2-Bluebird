using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] bool disableOnTrigger = true;
    [SerializeField] Transform spawnPoint;

    bool triggerActive = true;
    GameObject canActivate;

    private void Start()
    {
      canActivate = GameObject.FindGameObjectWithTag("Player");
    }

      void OnTriggerEnter(Collider other)
        {
            if(triggerActive && other.gameObject == canActivate)
            {
        
              Instantiate (prefab, spawnPoint.position,transform.rotation);
              if(disableOnTrigger)
              {triggerActive = false;}
            } 
            
        }   

         private void OnDrawGizmos()
        {
          Gizmos.color = Color.red;
          Gizmos.DrawSphere (transform.position,1f);
          Gizmos.color = Color.cyan;
          Gizmos.DrawSphere (spawnPoint.position,1f);

        } 
       
}
