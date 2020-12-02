using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    private GameObject m_playerCamera;
    private Rigidbody m_playerRigidBody;

    public GameObject m_player;
    public float m_followXZDistance = 10;
    public float m_followYDistance = 10;
    public float m_followXZSpeed = 10;
    public float m_followYSpeed = 10;
    public float m_followRotationSpeed = 10;


    void Start()
    {
        m_playerCamera = this.gameObject;
        m_playerRigidBody = m_player.GetComponent<Rigidbody>();
    }


    void Update()
    {
        
        FollowRotation();
        FollowPositionXZ();
        FollowPositionY();
        transform.LookAt(m_player.transform);
    }

    void FollowRotation()
    {
        Vector3 playerDirection = m_player.transform.forward;
        Vector3 cameraDirection = m_playerCamera.transform.forward;
        float anglesDifference = Vector2.SignedAngle(new Vector2(playerDirection.x, playerDirection.z), new Vector2(cameraDirection.x, cameraDirection.z));
        float angleToRotate = Mathf.Lerp(0, anglesDifference, m_followRotationSpeed * Time.deltaTime);
        transform.RotateAround(m_playerRigidBody.position, Vector3.up, angleToRotate);
    }

    void FollowPositionXZ()
    {
        Vector3 playerPosition = m_playerRigidBody.position;
        Vector3 cameraPosition = m_playerCamera.transform.position;
        playerPosition.y = 0;
        cameraPosition.y = 0;
        Vector3 diferencePosition = cameraPosition - playerPosition;

        Vector3 cameraEquilibriumPosition = playerPosition + diferencePosition.normalized * m_followXZDistance;
        Vector3 finalCameraPosition = Vector3.Lerp(cameraPosition, cameraEquilibriumPosition, m_followXZSpeed * Time.deltaTime);
        finalCameraPosition.y = m_playerCamera.transform.position.y;
        m_playerCamera.transform.position = finalCameraPosition;
    }

    void FollowPositionY()
    {
        float playerYPosition = m_playerRigidBody.position.y;
        float cameraYPosition = m_playerCamera.transform.position.y;

        float cameraYEquilibriumPosition = playerYPosition + m_followYDistance;
        float finalCameraYPosition = Mathf.Lerp(cameraYPosition, cameraYEquilibriumPosition, m_followYSpeed * Time.deltaTime);
        Vector3 finalCameraPosition = m_playerCamera.transform.position;
        finalCameraPosition.y = finalCameraYPosition;
        m_playerCamera.transform.position = finalCameraPosition;
    }
}
