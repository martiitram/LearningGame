using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoundUI : MonoBehaviour
{
    private UnityEngine.UI.Text m_goalText;
    private UnityEngine.UI.Text m_timeText;
    private GameRoundManager m_gameRoundManager;

    void Start()
    {
        m_goalText = gameObject.transform.Find("GoalText").GetComponent<UnityEngine.UI.Text>();
        m_timeText = gameObject.transform.Find("TimerText").GetComponent<UnityEngine.UI.Text>();
        m_gameRoundManager = GameObject.FindGameObjectWithTag("GameRoundManager").GetComponent<GameRoundManager>();
        SetTime(m_gameRoundManager.GetReminingTime());
        SetObjective();
    }

    public void SetObjective()
    {
        m_goalText.text = m_gameRoundManager.GetAmountOfCollectObjectives().ToString() + "/" + m_gameRoundManager.GetAmountOfObjectives().ToString();
    }

    void Update()
    {
        SetTime(m_gameRoundManager.GetReminingTime());
    }

    void SetTime(float timeInMilisecs)
    {
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
