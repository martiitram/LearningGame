using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreenBehaviour : MonoBehaviour
{
    public Button m_playButton;
    void Start()
    {
        m_playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        
    }
}
