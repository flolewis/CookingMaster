using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TopScore
{
    public string name;
    public int score;
}
[CreateAssetMenu(fileName = "New Leaderboard Data",menuName ="Data/Leaderboard")]
public class LeaderboardData : ScriptableObject
{
    public List<TopScore> topScores;

    private void OnEnable()
    {
        SortList();
    }
    public void SortList() {
        topScores.Sort(delegate(TopScore x,TopScore y) {
            return (x.score.CompareTo(y.score));
        });
        topScores.Reverse();
    }

    public void AddScore(string name,int score) {
        var ts = new TopScore();
        ts.name = name;
        ts.score = score;
        topScores.Add(ts);
    }
}
