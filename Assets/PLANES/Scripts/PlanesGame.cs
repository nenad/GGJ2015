using UnityEngine;
using System.Collections;

public class PlanesGame : MonoBehaviour {


    public static void SetPlanesActive(bool status)
    {
        var planesUI = GameObject.Find("UI/PlanetGameUI");

        var self = GameObject.FindObjectOfType<PlanesGame>();
        foreach (Transform t in self.transform)
        {
            t.gameObject.SetActive(status);
        }
        if (status)
        {
            var r = GameObject.FindObjectOfType<Reset>();
            r.ResetGame();
        }
        planesUI.SetActive(status);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SetPlanesActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetPlanesActive(false);
        }
    }

}
