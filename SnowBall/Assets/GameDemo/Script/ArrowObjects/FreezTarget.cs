using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezTarget : MonoBehaviour {

	float _time = 0.0f;

	private void Update( ) {
		if ( _time > 0 ) {
			_time += Time.deltaTime;
		}
		if ( _time > 3 ) {
			GetComponent<Rigidbody>( ).velocity = Vector3.zero;
		}
	}

	private void OnCollisionEnter( Collision collision ) {
		Rigidbody rb = GetComponent<Rigidbody>( );
		rb.useGravity = true;
		_time += Time.deltaTime;
	}
}
