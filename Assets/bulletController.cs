using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

	public float force = 300f;

	// Use this for initialization
	void Start () {
		transform.GetComponent<Rigidbody>().AddForce(transform.forward * force);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		transform.GetComponent<Rigidbody> ().isKinematic = true;      
	}
}
