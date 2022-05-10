using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "New Leaderboard Data",menuName ="Data/Leaderboard")]
public class LeaderboardData : ScriptableObject
{
	[System.Serializable]
	public class TopScore
	{
		public string name;
		public int score;
	}
	public List<TopScore> topScores = new List<TopScore>();

	private string gameDataProjectFilePath;
	private void OnEnable()
	{
		#if UNITY_ANDROID
						gameDataProjectFilePath = System.IO.Path.Combine(Application.persistentDataPath, "GameData.json");
		#endif

		#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_WIN || UNITY_STANDALONE
				gameDataProjectFilePath = Application.dataPath + "/streamingAssets/GameData.json";
#endif
		SortList();
		this.topScores = new List<TopScore>();
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

	public void Save()
	{
		string dataAsJson = JsonHelper.ToJson(this.topScores);
		string filePath = gameDataProjectFilePath;
		File.WriteAllText(filePath, dataAsJson);
	}

	public void Load()
	{
		string filePath = gameDataProjectFilePath;

		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			this.topScores = JsonHelper.FromJson<TopScore>(dataAsJson);
		}
	}

	public void ClearData()
	{
		topScores.Clear();

	}
}
