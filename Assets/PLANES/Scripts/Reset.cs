using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    Score score;
    Player player;

	// Use this for initialization
	void Start () {
        score = GameObject.FindObjectOfType<Score>();
        player = GameObject.FindObjectOfType<Player>();
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

        Map m = GameObject.FindObjectOfType<Map>();
        m.transform.position = new Vector3(0, 12.5f);

    }

	// Update is called once per frame
	void Update () {
	
	}
}
