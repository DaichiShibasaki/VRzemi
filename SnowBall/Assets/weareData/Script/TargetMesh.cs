using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMesh : MonoBehaviour {

	[SerializeField] GameObject _target;

	private void OnCollisionEnter( Collision collision ) {
		_target.GetComponent<AnimalTarget>().hit( );
	}
}
