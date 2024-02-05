using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;

    private GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();

        easyButton.onClick.AddListener(() => { gameManagerScript.StartGame(1); } );
        mediumButton.onClick.AddListener(() => { gameManagerScript.StartGame(2); });
        hardButton.onClick.AddListener(() => { gameManagerScript.StartGame(3); });
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimeText(int time)
    {
        timeText.text = "Time: " + time;
    }

    public void UpdateLifesText(int lifes)
    {
        lifeText.text = "Lifes: " + lifes;
    }

    public void ShowGameOverPanel(int score)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score;
    }

    public void ShowPauseMenu()
    {
        pausePanel.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pausePanel.SetActive(false);
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        
    }

    public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);

    }

    public void HideMainMenuPanel()
    {
        mainMenuPanel.SetActive(false);

    }

}
