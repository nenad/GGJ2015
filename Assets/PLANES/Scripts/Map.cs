using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}

    public void Reset()
    {
        transform.position = startingPosition;
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * 0.3f);
	}
}
