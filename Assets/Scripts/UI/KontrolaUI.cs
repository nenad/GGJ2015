using UnityEngine;
using System.Collections;

public class KontrolaUI : MonoBehaviour {
    int prevKontrolaState = -1;
    public TextMesh textMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (prevKontrolaState != LevelState.KontrolaLeft)
        {
            textMesh.text = LevelState.KontrolaLeft + " Left";
            prevKontrolaState = LevelState.KontrolaLeft;
        }
	}
}
