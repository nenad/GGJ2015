using UnityEngine;
using System.Collections;

public class AutoLevelSwitch : MonoBehaviour {

    public static float switchTime = -1;

	// Use this for initialization
	void Start () {
        if (switchTime < 0)
        {
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > switchTime)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
	}
}
