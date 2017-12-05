using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	
	Vector3 _vec;

	// Use this for initialization
	void Start( ) {
		GetComponent<Rigidbody>( ).velocity = _vec;
	}

	// Update is called once per frame
	void Update( ) {
	}

	public void setDirection( Quaternion q, Vector3 ahead, float speed ) {
		transform.rotation = q;
		_vec = ahead.normalized * speed;
		Object.Destroy( gameObject, 15.0f );
	}
}
