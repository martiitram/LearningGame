using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoundManager : MonoBehaviour
{
    private int m_amoutOfObjectives;
    private float m_currentTime;
    private GameObject[] m_goalSpawnPoints;
    private GameObject m_uiGameObjectRoot;

    public GameObject m_goalsPrefab;
    public int m_timeInSeconds;

    void Awake()
    {
        if (m_goalSpawnPoints == null)
            m_goalSpawnPoints = GameObject.FindGameObjectsWithTag("goalSpawnPoint");

        foreach (GameObject spawnPoint in m_goalSpawnPoints)
        {
            ++m_amoutOfObjectives;
            Destroy(spawnPoint);
            Instantiate(m_goalsPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

        m_currentTime = 0;
    }
    
    public int GetAmountOfObjectives()
    {
        return m_amoutOfObjectives;
    }

    public float GetReminingTime()
    {
        return m_timeInSeconds * 1000 - m_currentTime * 1000;
    }

    void Update()
    {
        m_currentTime += Time.deltaTime;
    }
}
