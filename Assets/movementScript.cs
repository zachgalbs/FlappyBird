using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    public GameObject pipe;
    public float jumpHeight;
    private float lastTime;
    public float creationDelay; 
    private float[] ySlotValues = {-2.5F, 2.5F};

    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        // This is saying: whenever w is pressed, move up the object by a certain amount
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += Vector3.up * jumpHeight;
        }
        // This is the code to make multiple pipes
        if (Time.time - lastTime > creationDelay)
        {
            int upOrDown = Random.Range(0,2);
            Debug.Log(ySlotValues[upOrDown]);
            GameObject newpipe = Instantiate(pipe, new Vector3(11F, ySlotValues[upOrDown], 0F), Quaternion.identity);
            lastTime = Time.time;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "pipes")
        {
            Debug.Log("Collision");
            
        }
    }
}
