using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonBehaviour : MonoBehaviour
{
    public Button m_button;
    public int screen_number;
    void Start()
    {
        m_button.onClick.AddListener(OnPlayButtonClicked);
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(screen_number);
    }
    void Update()
    {
        
    }
}
