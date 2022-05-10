using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public PlayerData[] players;
    public LeaderboardData lData;
    public GameObject startGamePanel,endGamePanel;
    public Timer[] timers;
    public TextMeshProUGUI winnerText;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void UpdateUI()
    {
        if (timers[0].ended && timers[1].ended)
        {
            endGamePanel.SetActive(true);
            if (players[0].score > players[1].score)
            {
                winnerText.text = players[0].name + " Win!";
                if (lData.topScores.Count < 3) {
                    lData.AddScore(players[0].name, (int)players[0].score);
                }
                else if (lData.topScores[lData.topScores.Count - 1].score < players[0].score) {
                    lData.AddScore(players[0].name, (int)players[0].score);
                }
            }
            else if (players[1].score > players[0].score)
            {
                winnerText.text = players[1].name + " Win!";
                if (lData.topScores.Count < 3)
                {
                    lData.AddScore(players[1].name, (int)players[1].score);
                }
                else if (lData.topScores[lData.topScores.Count - 1].score < players[1].score)
                {
                    lData.AddScore(players[1].name, (int)players[1].score);
                }
            }
            else {
                winnerText.text = "Draw!";
            }
            lData.SortList();
        }
        else {
            endGamePanel.SetActive(false);
        }
    }
    public void StartGame() {
        startGamePanel.SetActive(false);
        Time.timeScale = 1;
        timers[0].StartTimer();
        timers[1].StartTimer();
    }
    public void RestartScene() {
        SceneManager.LoadScene("Game Scene");
    }
}
