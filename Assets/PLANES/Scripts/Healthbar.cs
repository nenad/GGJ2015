using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {

    TextMesh text;
    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
        text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "Health: " + player.Health;

	}
}
