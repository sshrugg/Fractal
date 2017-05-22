﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractal : MonoBehaviour {

    public Mesh mesh;
    public Material material;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
