using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{

    public GameObject pipe;
    public float jumpHeight;
    private float lastTime;
    public float creationDelay; 
    private float[] ySlotValues = {-2.5F, 2.5F};
    private Vector3 direction;
    private float gravity = -7.8F;
    private bool collisionOccured = false;
    private bool endgame = false;
    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        // This is saying: whenever w is pressed, move up the object by a certain amount
        if (Input.GetKeyDown(KeyCode.Space) && !collisionOccured)
        {
            direction = Vector3.up * jumpHeight;
        }

        // This is the code to make multiple pipes
        if (Time.time - lastTime > creationDelay)
        {
            int upOrDown = Random.Range(0,2);
            GameObject newpipe = Instantiate(pipe, new Vector2(11F, ySlotValues[upOrDown]), Quaternion.identity);
            lastTime = Time.time;
        }
        if (!endgame)
        {
        transform.position += direction * Time.deltaTime;
        direction.y += gravity * Time.deltaTime;
        }
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        
        SceneManager.LoadScene("gameOver");

        if (col.collider.tag == "pipes")
        {
            Debug.Log("Collision");
            collisionOccured = true;
            endgame = true;
        }
        if (col.collider.tag == "Wall")
        {
            Debug.Log("end level");
            endgame = true;
        }





    }
}
