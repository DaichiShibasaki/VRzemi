using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

	[SerializeField] GameObject _arrow = null;
	[SerializeField] Transform _foword = null;
	[SerializeField] Transform _back = null;

	[SerializeField] int _interval = 240;
	[SerializeField] float _arrow_speed = 20;
	public int _time = 0;

	// Use this for initialization
	void Start( ) {
	}

	// Update is called once per frame
	void Update( ) {
		if ( _time == 0 ) {
			Vector3 ahead = transform.TransformPoint( _foword.position ) - transform.TransformPoint( _back.position );
			Vector3 dir = Vector3.Cross( Vector3.up, ahead ).normalized;
			float angle = Mathf.Acos( Vector3.Dot( Vector3.up, ahead ) );
			Quaternion q = Quaternion.AxisAngle( dir, angle );

			GameObject arrow = Instantiate( _arrow, transform.position + new Vector3( 0, 0.5f, 0 ), new Quaternion( 0, 0, 0, 0 ) );
			arrow.AddComponent<Rigidbody>( );
			arrow.AddComponent<Arrow>( );
			arrow.GetComponent<Arrow>( ).setDirection( q, ahead, _arrow_speed );
		}
		_time = ( _time + 1 ) % _interval;
	}
}
