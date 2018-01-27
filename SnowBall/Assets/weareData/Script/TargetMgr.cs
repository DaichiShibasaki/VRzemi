using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMgr : MonoBehaviour {

	[SerializeField] GameObject[] _wave;
	int _wave_count;
	int _hit_count;

	// Use this for initialization
	void Start () {
		_wave_count = 0;
		_wave[ _wave_count ].SetActive( true );
	}
	
	// Update is called once per frame
	void Update () {
		if ( _wave[ _wave_count ].transform.childCount == 0 ) {
			_wave_count++;
			_wave[ _wave_count ].SetActive( true );
		}
	}

	public void Hitting( ) {
		_hit_count++;
	}
	
	public int getHitCount( ) {
		return _hit_count;
	}
}
