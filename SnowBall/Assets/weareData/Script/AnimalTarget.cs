using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTarget : MonoBehaviour {

	[SerializeField] GameObject _target_mgr;
	bool _hit;

	private void Start( ) {
		_hit = false;
	}

	void OnCollisionEnter( Collision collision ) {
		if ( _hit ) {
			return;
		}
		Destroy( gameObject, 3f );
		_target_mgr.GetComponent<TargetMgr>().Hitting( );
		_hit = true;
	}
}
