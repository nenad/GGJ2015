using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    Score score;
    Player player;
    Map map;

	// Use this for initialization
	void Start () {
        score = GameObject.FindObjectOfType<Score>();
        player = GameObject.FindObjectOfType<Player>();
        map = GameObject.FindObjectOfType<Map>();
	}

    public void ResetGame()
    {
        score.ResetScore();
        player.ResetPlayer();

        var planes = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy e in planes)
        {
            Destroy(e.gameObject);
        }

        var bullets = GameObject.FindObjectsOfType<Bullet>();
        foreach (Bullet b in bullets)
        {
            Destroy(b.gameObject);
        }

        map.Reset();

    }

	// Update is called once per frame
	void Update () {
	
	}
}
