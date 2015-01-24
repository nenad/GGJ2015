using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int score = 0;
    TextMesh text;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetScore()
    {
        text.text = "Score: 0";
        score = 0;
    }

    internal void Add(int p)
    {
        score += p;
        text.text = "Score: " + score;
    }
}
