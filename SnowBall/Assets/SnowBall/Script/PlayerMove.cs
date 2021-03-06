﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private float speed;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetKey( KeyCode.W ) )
        {
            transform.Translate( Vector3.forward * speed * Time.deltaTime );
        }
        if ( Input.GetKey( KeyCode.S ) ) {
            transform.Translate( Vector3.back * speed * Time.deltaTime );
        }
        if ( Input.GetKey( KeyCode.D ) ) {
            transform.Translate( Vector3.right * speed * Time.deltaTime );
        }
        if ( Input.GetKey( KeyCode.A ) ) {
            transform.Translate( Vector3.left * speed * Time.deltaTime );
        }

        if ( Input.GetKey( KeyCode.RightArrow ) ) {
            transform.Rotate( new Vector3( 0, 1f, 0 ) );
        }
        if ( Input.GetKey( KeyCode.LeftArrow ) ) {
            transform.Rotate( new Vector3( 0, -1f, 0 ) );
        }
    }
}
