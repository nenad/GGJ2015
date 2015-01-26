using UnityEngine;
using System.Collections;

public class WCAudio : MonoBehaviour {

    public AudioClip wcAudio;
	// Use this for initialization
	void Start () {

        StartCoroutine(IEWCAudio());

	}

    private IEnumerator IEWCAudio()
    {
        yield return new WaitForSeconds(20f);
        AudioSource.PlayClipAtPoint(wcAudio, Camera.main.transform.position, 100);
    }
}
