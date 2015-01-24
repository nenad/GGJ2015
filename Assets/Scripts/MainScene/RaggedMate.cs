using UnityEngine;
using System.Collections;

public class RaggedMate : MonoBehaviour {

    void GetRekt()
    {
        animation.Stop();
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>().mass = 0.1f;
        foreach (Transform t in transform)
        {
            if (t.childCount > 0)
            {
                for (int i = 0; i < t.childCount; i++)
                {
                    t.GetChild(i).gameObject.AddComponent<BoxCollider>();
                    t.GetChild(i).gameObject.AddComponent<Rigidbody>().mass = 0.1f;
                }
            }
            t.gameObject.AddComponent<BoxCollider>();
            t.gameObject.AddComponent<Rigidbody>().mass = 0.1f;
        }
    }

	// Use this for initialization
	void Start () {
        GetRekt();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
