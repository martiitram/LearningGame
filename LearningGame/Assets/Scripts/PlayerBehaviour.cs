using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject player;
    private Rigidbody playerRigidBody;

    public int velocity = 1;
    
    void Start()
    {
        player = this.gameObject;
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if (Input.GetKey("up"))
        {
            direction += new Vector3(0,0,1);
        }
        if (Input.GetKey("down"))
        {
            direction += new Vector3(0,0,-1);
        }
        if (Input.GetKey("right"))
        {
            direction += new Vector3(1,0,0);
        }
        if (Input.GetKey("left"))
        {
            direction += new Vector3(-1,0,0);
        }
        playerRigidBody.velocity = direction * velocity;
    }
}
