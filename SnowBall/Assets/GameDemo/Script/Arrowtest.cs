using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowtest : MonoBehaviour {

    [SerializeField] SteamVR_TrackedObject bow; //Controller (left)
    [SerializeField] SteamVR_TrackedObject arrow; //Controller (right)
    
	public GameObject prefab;
	public Rigidbody attachPoint;
    public Transform Backward;
	FixedJoint joint;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)arrow.index);
        Vector3 distance = bow.transform.position - arrow.transform.position;
        float length = distance.magnitude;
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && length < 0.1f)
		{
			var go = GameObject.Instantiate(prefab);
			go.transform.position = attachPoint.transform.position;

			joint = go.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
		}
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = joint.gameObject;
			var rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			Object.Destroy(go, 15.0f);
            
			rigidbody.velocity = distance.normalized * ( ( distance.magnitude / 10 ) * 100 );

			//rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }

        if ( joint ) {
            Vector3 scale = joint.transform.localScale;
            scale.x = length;
            scale.z = length;
            joint.transform.localScale = scale;

            Vector3 pos = joint.transform.position;
            pos.x = bow.transform.position.x - ( distance.x / 2 );
            pos.z = bow.transform.position.z - ( distance.z / 2 );
            joint.transform.position = pos;
        }
	}

}
