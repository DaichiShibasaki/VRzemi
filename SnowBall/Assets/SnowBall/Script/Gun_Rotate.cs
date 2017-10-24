using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetKey( KeyCode.UpArrow ) ) {
            transform.Rotate( new Vector3( -1f, 0, 0 ) );
        }
        if ( Input.GetKey( KeyCode.DownArrow ) ) {
            transform.Rotate( new Vector3( 1f, 0, 0 ) );
        }
    }
}
