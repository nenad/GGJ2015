using UnityEngine;
using System.Collections;

public class Dark1Member : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(IERandom());
	}

    IEnumerator IERandom()
    {
        while (true)
        {
            var random = Random.Range(3f, 5f);
            yield return new WaitForSeconds(random);
            gameObject.SampleAnimation(animation.clip, 0);
            animation.Stop();

            random = Random.Range(3f, 5f);
            yield return new WaitForSeconds(random);
            animation.Play();
        }
    }
}
