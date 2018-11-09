using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoy_by_time : MonoBehaviour {
	public float lifetime;
	
	void Start () {
		Destroy (gameObject, lifetime);
	}
}
