using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject m_player;
    private Rigidbody m_playerRigidBody;

    public int m_velocity = 1;
    public int m_jumpVelocity = 10;
    public float m_distanceToFloor = 1f;
    public Joystick m_joystick;
    public Button m_jumpButton;
    
    void Start()
    {
        m_player = this.gameObject;
        m_playerRigidBody = m_player.GetComponent<Rigidbody>();
        m_jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    bool IsOnFloor()
    {
        return Physics.Raycast(m_player.transform.position, new Vector3(0, -1, 0), m_distanceToFloor);
    }

    Vector3 GetVelocity()
    {
        Vector3 velocity = m_playerRigidBody.velocity;
        velocity.x = m_joystick.Horizontal * m_velocity;
        velocity.z = m_joystick.Vertical * m_velocity;
        return velocity;
    }

    void OnJumpButtonClicked()
    {
        if (IsOnFloor())
        {
            Vector3 direction = m_playerRigidBody.velocity;
            direction.y = m_jumpVelocity;
            m_playerRigidBody.velocity = direction;
        }
    }

    void FixedUpdate()
    {
        m_playerRigidBody.velocity = GetVelocity();

        #if UNITY_EDITOR
            DebugUpdate();
        #endif
    }


#if UNITY_EDITOR
    void DebugUpdate(){
        if (Input.GetKey("space"))
        {
            OnJumpButtonClicked();
        }

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

        m_playerRigidBody.velocity += direction.normalized * m_velocity;
    }
#endif


}
