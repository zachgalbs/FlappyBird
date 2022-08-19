using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    public GameObject pipe;
    public float jumpHeight;
    private float lastTime;
    private float smoothTime = 0.3F;
    public float creationDelay; 
    private float[] ySlotValues = {-2.5F, 2.5F};
    private Vector3 targetPosition;

    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        // This is saying: whenever w is pressed, move up the object by a certain amount
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.position += Vector3.up * jumpHeight;
            // This is for the smooth animation
            ypos = transform.position.y + Vector3.up * jumpHeight;
            Vector3 newPos = new Vector3(transform.position.x, (ypos), transform.position.z);
            targetPosition = newPos;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref jumpHeight, smoothTime);
        }

        // This is the code to make multiple pipes
        if (Time.time - lastTime > creationDelay)
        {
            int upOrDown = Random.Range(0,2);
            GameObject newpipe = Instantiate(pipe, new Vector2(11F, ySlotValues[upOrDown]), Quaternion.identity);
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
