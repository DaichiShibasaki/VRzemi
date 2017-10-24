using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField] private float deceleration;
    [SerializeField]
    private float deleteTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( Vector3.forward * speed * Time.deltaTime );
        if ( 0 < speed ) {
            speed -= deceleration;
        }

        Destroy( this.gameObject, deleteTime );
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
