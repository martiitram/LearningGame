using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBehaviour : MonoBehaviour
{
    private GameObject m_objectiveGameObject;
    private GameRoundManager m_gameRoundManager;
    
    void Start()
    {
        m_objectiveGameObject = this.gameObject;
        m_gameRoundManager = GameObject.FindGameObjectWithTag("GameRoundManager").GetComponent<GameRoundManager>();
    }
    
    void Update()
    {
        m_objectiveGameObject.transform.Rotate(new Vector3(0, 1, 0), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        m_gameRoundManager.OnObjectiveDestroyed();
        Destroy(this.transform.parent.gameObject);
    }
}
