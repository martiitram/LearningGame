using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private GameObject m_player;
    private Rigidbody m_playerRigidBody;

    public Camera m_playerCamera;
    public int m_velocity = 1;
    public int m_jumpVelocity = 10;
    public float m_distanceToFloor = 1f;
    public float m_yCameraRotationVelocity = 100;
    public Joystick m_joystick;
    public Button m_jumpButton;
    public float m_gravityConstant = 50;

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
        float joystickModule = m_joystick.Direction.magnitude;
        Vector3 velocity = Vector3.forward * joystickModule * m_velocity;
        velocity.y = m_playerRigidBody.velocity.y - m_gravityConstant * Time.deltaTime;
        return GetRotation() * velocity;
    }

    void UpdateVelocity()
    {
        m_playerRigidBody.velocity = GetVelocity();
    }


    Quaternion GetRotation()
    {
        float JoistickAngle = Vector2.SignedAngle( m_joystick.Direction, new Vector2(0, 1));
        Quaternion joisticRotation = Quaternion.Euler(new Vector3(0, JoistickAngle, 0));
        return getCameraRotationXZ() * joisticRotation;
    }

    void UpdateRotation()
    {
        if(m_joystick.Direction.magnitude > 0)
        {
            m_playerRigidBody.rotation = GetRotation();
        }
    }

    Quaternion getCameraRotationXZ()
    {
        Vector3 cameraDirection = m_playerCamera.transform.forward;
        float cameraAngle = Vector2.SignedAngle(new Vector2(cameraDirection.x, cameraDirection.z), new Vector2(0, 1));
        Quaternion cameraRotation = Quaternion.Euler(new Vector3(0, cameraAngle, 0));
        return cameraRotation;
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
        UpdateVelocity();
        UpdateRotation();        
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
