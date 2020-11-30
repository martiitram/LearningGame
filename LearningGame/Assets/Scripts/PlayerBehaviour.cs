using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject m_player;
    private Rigidbody m_playerRigidBody;
    private bool m_jump;
    private float m_jumpTime;

    public int m_velocity = 1;
    public int m_jumpVelocity = 1;
    public float m_jumpDuration = 1.0f;
    public Joystick m_joystick;
    public Button m_jumpButton;
    
    void Start()
    {
        m_player = this.gameObject;
        m_playerRigidBody = m_player.GetComponent<Rigidbody>();
        m_jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    void OnJumpButtonClicked()
    {
        if (Mathf.Abs(m_playerRigidBody.velocity.y) < 0.2 && !m_jump)
        {
            m_jump = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, 0.0f);
        if (m_jump)
        {
            m_jumpTime += Time.deltaTime;
            if (m_jumpTime > m_jumpDuration)
            {
                m_jumpTime = 0.0f;
                m_jump = false;
            }
            int jumpDirection = m_jumpTime < m_jumpDuration / 2 ? 1 : -1;
            direction.y = jumpDirection * m_jumpVelocity;
        }
        if (m_joystick.Horizontal > 0)
        {
            direction += new Vector3(1, 0, 0) * m_velocity;
        }
        else if (m_joystick.Horizontal < 0)
        {
            direction += new Vector3(-1, 0, 0) * m_velocity;
        }

        if (m_joystick.Vertical > 0)
        {
            direction += new Vector3(0, 0, 1) * m_velocity;
        }
        else if (m_joystick.Vertical < 0)
        {
            direction += new Vector3(0, 0, -1) * m_velocity;
        }
        m_playerRigidBody.velocity = direction;
    }
}
