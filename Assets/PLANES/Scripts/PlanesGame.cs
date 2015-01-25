using UnityEngine;
using System.Collections;

public class PlanesGame : MonoBehaviour {

    static DiveFPSController dive;
    public static bool isPlaying = false;
    public AudioClip newGame;
    public AudioClip gameOver;
    public AudioClip shoot;

    void Start()
    {
        dive = GameObject.FindObjectOfType<DiveFPSController>();
        AudioSource.PlayClipAtPoint(newGame, Camera.main.transform.position);
    }

    public static void SetPlanesActive(bool status)
    {
        isPlaying = status;
        dive.enabled = !status;
        //var planesUI = GameObject.Find("UI/PlanetGameUI");

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
        //planesUI.SetActive(status);
    }

    void Update()
    {

    }

}
