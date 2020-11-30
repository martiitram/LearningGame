using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject m_player;
    private Rigidbody m_playerRigidBody;

    public int m_velocity = 1;
    public Joystick m_joystick;
    
    void Start()
    {
        m_player = this.gameObject;
        m_playerRigidBody = m_player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        if (m_joystick.Horizontal > 0)
        {
            direction += new Vector3(1, 0, 0);
        }
        else if (m_joystick.Horizontal < 0)
        {
            direction += new Vector3(-1, 0, 0);
        }

        if (m_joystick.Vertical > 0)
        {
            direction += new Vector3(0, 0, 1);
        }
        else if (m_joystick.Vertical < 0)
        {
            direction += new Vector3(0, 0, -1);
        }
        m_playerRigidBody.velocity = direction * m_velocity;
    }
}
