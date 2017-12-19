using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveCamera : MonoBehaviour {
	
	[SerializeField] GameObject _main;
	[SerializeField] GameObject [] _live;
	int _current_camera_idx = 0;
	const int MAX_LIVE_CAMERA = 4;

	private void Start( ) {
		UnityEngine.VR.VRSettings.showDeviceView = false;
	}

	private void Update( ) {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			_live[_current_camera_idx].SetActive( false );
			_live[(_current_camera_idx + 1) % MAX_LIVE_CAMERA].SetActive( true );
			_current_camera_idx = ( _current_camera_idx + 1 ) % MAX_LIVE_CAMERA;
		}
	}
}
