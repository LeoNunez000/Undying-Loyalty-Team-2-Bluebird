using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] bool disableOnTrigger = true;

    bool triggerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

      void OnTriggerEnter(Collider other)
        {
            Debug.Log("its working");
            Instantiate (prefab, transform.position,transform.rotation);
        }    
       
}
