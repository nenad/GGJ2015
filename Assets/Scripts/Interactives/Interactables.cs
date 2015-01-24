using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactables : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


	}

    public virtual void Use()
    {
        Debug.Log("Used: " + name);
    }
}
