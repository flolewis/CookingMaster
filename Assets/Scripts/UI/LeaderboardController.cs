using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardController : MonoBehaviour
{
    public LeaderboardData data;
    public GameObject dataText,parentObj;
	public void Start()
    {
        UpdateList();
    }
    public void UpdateList() {
        foreach (LeaderboardData.TopScore topScore in data.topScores) {
            var go = Instantiate(dataText,parentObj.transform);
            go.SetActive(true);
            go.GetComponent<TextMeshProUGUI>().text = topScore.name + " - " + topScore.score;
        }
    }


}
