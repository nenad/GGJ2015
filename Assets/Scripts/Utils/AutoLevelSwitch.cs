using UnityEngine;
using System.Collections;

public class AutoLevelState
{
    public static float switchTime = -1;
    public static string LevelName;
}

public class AutoLevelSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (AutoLevelState.switchTime < 0)
        {
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > AutoLevelState.switchTime)
        {
            Debug.Log("Levelname: " + AutoLevelState.LevelName);
            if (AutoLevelState.LevelName == null || AutoLevelState.LevelName == string.Empty)
                Application.LoadLevel(Application.loadedLevel + 1);
            else
                Application.LoadLevel(AutoLevelState.LevelName);
        }
	}
}
