using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_by_boundray : MonoBehaviour {

	void Start () {
		
	}
	
	void OnTriggerExit(Collider other){
		Destroy(other.gameObject);
	}

	void Update () {
		
	}
}
