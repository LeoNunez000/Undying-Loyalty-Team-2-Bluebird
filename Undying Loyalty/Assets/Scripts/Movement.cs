using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
     void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime*MoveSpeed;
        float zValue = Input.GetAxis("Vertical")*Time.deltaTime*MoveSpeed;
        transform.Translate(xValue,0,zValue);

    }
   
}
