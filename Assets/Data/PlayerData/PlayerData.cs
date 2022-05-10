using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player Data",menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public float timer;
    public float score;
    public void ResetScore() {
        score = 0;
    }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
    }
}
