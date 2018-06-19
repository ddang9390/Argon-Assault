using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    Text score;
    int totalScore;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        score.text = totalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gainPoints(int points)
    {
        totalScore += points;
        score.text = totalScore.ToString();
    }

    public void gainPointsWhileAlive()
    {
        totalScore ++;
        score.text = totalScore.ToString();
    }
}
