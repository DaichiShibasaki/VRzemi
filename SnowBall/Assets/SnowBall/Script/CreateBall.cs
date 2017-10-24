using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour {
    [SerializeField]
    private GameObject Snowball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
           Instantiate( Snowball, transform.position, transform.rotation );
        }
	}
}
