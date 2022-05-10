using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public PlayerData pData;
    public TextMeshProUGUI scoreUI;
    public Timer timer;

    private void Start()
    {
        timer.timer = pData.timer;
    }

    private void Update()
    {
        scoreUI.text = "Score: " + pData.score.ToString();
    }
}
