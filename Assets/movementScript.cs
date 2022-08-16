using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{


    public float jumpHeight = 50; 

    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // This is saying: whenever w is pressed, move up the object by a certain amount
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += Vector3.up * jumpHeight;
        }
    }
}
