using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private int field_sizeX;
    [SerializeField]
    private float speed;
    private int time;
    [SerializeField]
    private int ball_interbal;
    [SerializeField]
    private GameObject Snowball;
    [SerializeField]
    private GameObject Snowball_pos;
    [SerializeField]private GameObject hitMess;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Move
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if ( transform.position.x <= -field_sizeX || field_sizeX < transform.position.x )
        {
            speed *= -1;
        }

        //Attack
        time++;
        if ( ball_interbal <= time )
        {
            Instantiate(Snowball, Snowball_pos.transform.position, Snowball_pos.transform.rotation);
            time = 0;
        }
    }

    void OnCollisionEnter(Collision collision ) {
        if(collision.gameObject.tag == "Player" ){
            Instantiate( hitMess, transform.position, Quaternion.identity );
        }
  }
}
