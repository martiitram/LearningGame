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
    public float m_yAngleVelocity = 100;
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
        Vector3 velocity = transform.forward * m_joystick.Vertical * m_velocity;
        velocity.y = m_playerRigidBody.velocity.y;
        return velocity;
    }

    Quaternion GetRotation()
    {
        Vector3 m_EulerAngleVelocity = new Vector3(0, m_yAngleVelocity, 0);
        m_EulerAngleVelocity *= m_joystick.Horizontal;
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        return m_playerRigidBody.rotation * deltaRotation;
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
#if UNITY_EDITOR
            DebugUpdate();
#endif
        m_playerRigidBody.velocity = GetVelocity();
        m_playerRigidBody.MoveRotation(GetRotation());

        
    }


#if UNITY_EDITOR
    void DebugUpdate(){
        if (Input.GetKey("space"))
        {
            OnJumpButtonClicked();
        }
    }
#endif


}
