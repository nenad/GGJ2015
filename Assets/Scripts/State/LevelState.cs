using UnityEngine;
using System.Collections;

public class LevelState : MonoBehaviour {

    public static int KontrolaLeft;
    public AudioSource musicSource;

	// Use this for initialization
	void Start () {
        EnemyConductor[] enemies = GameObject.FindObjectsOfType<EnemyConductor>();
        LevelState.KontrolaLeft = enemies.Length;
	}

    void FixedUpdate()
    {
        if (KontrolaLeft == 0)
        {
            musicSource.Stop();
            StartCoroutine(DelayedLoad());
        }
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(15f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
