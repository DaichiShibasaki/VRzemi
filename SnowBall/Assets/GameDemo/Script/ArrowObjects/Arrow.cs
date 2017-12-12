using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	
	bool _on_sky = true;

	// Use this for initialization
	void Start( ) {
	}

	// Update is called once per frame
	void Update( ) {
		if ( _on_sky ) {
			Vector3 vec = GetComponent<Rigidbody>().velocity.normalized;
			Vector3 dir = Vector3.Cross( Vector3.up, vec ).normalized;
			float angle = Mathf.Acos( Vector3.Dot( Vector3.up, vec ) );
			Quaternion q = Quaternion.AxisAngle( dir, angle );
			transform.rotation = q;
		}
	}

	private void OnCollisionEnter( Collision collision ) {
		if ( collision.collider.tag == "Plane" ) {
			_on_sky = false;
		}
		if ( collision.collider.tag == "FreezTarget" ) {
			collision.transform.SetParent( gameObject.transform );
			collision.transform.GetComponent<Rigidbody> ().velocity = transform.GetComponent<Rigidbody>().velocity;
			collision.transform.GetComponent<Rigidbody> ().angularVelocity = transform.GetComponent<Rigidbody>().angularVelocity;
		}
	}
}
