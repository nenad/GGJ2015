using UnityEngine;
using System.Collections;

public class Peasant : MonoBehaviour {

    public MeshRenderer leftSleeve;
    public MeshRenderer rightSleeve;
    public MeshRenderer body;

	// Use this for initialization
	void Start () {

        float r = Random.Range(0, 1f);
        float g = Random.Range(0, 1f);
        float b = Random.Range(0, 1f);

        leftSleeve.material.color = new Color(r, g, b);
        rightSleeve.material.color = new Color(r, g, b);
        body.material.color = new Color(r, g, b);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
