﻿using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * 0.3f);
	}
}
