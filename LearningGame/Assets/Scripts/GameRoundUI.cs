using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoundUI : MonoBehaviour
{
    private UnityEngine.UI.Text m_objectiveText;
    private UnityEngine.UI.Text m_timeText;
    private GameRoundManager m_gameRoundManager;

    void Start()
    {
        m_objectiveText = gameObject.transform.Find("GoalText").GetComponent<UnityEngine.UI.Text>();
        m_timeText = gameObject.transform.Find("TimerText").GetComponent<UnityEngine.UI.Text>();
        m_gameRoundManager = GameObject.FindGameObjectWithTag("GameRoundManager").GetComponent<GameRoundManager>();
        UpdateUI();
    }

    public void SetObjective()
    {
        m_objectiveText.text = m_gameRoundManager.GetAmountOfCollectObjectives().ToString() + "/" + m_gameRoundManager.GetAmountOfObjectives().ToString();
    }

    public void UpdateUI()
    {
        SetTime();
        SetObjective();
    }

    void Update()
    {
        UpdateUI();
    }

    void SetTime()
    {
        float timeInMilisecs = m_gameRoundManager.GetReminingTime();
        int minutes = (int)(timeInMilisecs / 60 / 1000);
        string minutesText = minutes.ToString();
        minutesText = minutes < 10 ? "0" + minutesText : minutesText;
        timeInMilisecs = timeInMilisecs - (minutes * 60 * 1000);

        int seconds = (int)(timeInMilisecs / 1000);
        string secondsText = seconds.ToString();
        secondsText = seconds < 10 ? "0" + secondsText : secondsText;
        
        m_timeText.text = minutesText + ":" + secondsText;
    }
}
