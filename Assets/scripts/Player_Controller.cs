using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class Player_Controller : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary bounday;
	private Rigidbody rb;
	private AudioSource au;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;


	void Start () {
		rb = GetComponent<Rigidbody>();
		au = GetComponent<AudioSource>();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, bounday.xMin, bounday.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, bounday.zMin, bounday.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

	}
	
	void Update () {
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
        	nextFire = Time.time + fireRate;
        	Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        	au.Play();
        }
	}
}
