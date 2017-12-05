using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowtest : MonoBehaviour {

    [SerializeField] Transform left; //Controller (left)
    [SerializeField] Transform right; //Controller (right)
    [SerializeField] SteamVR_TrackedObject arrow; //Controller (right)
    [SerializeField] float _speed = 100;
	public GameObject prefab;
	public Rigidbody attachPoint;
	FixedJoint joint;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)arrow.index);
        Vector3 distance = right.position - left.position;
        float length = distance.magnitude;
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && length < 0.2f)
		{
			var go = GameObject.Instantiate(prefab);
			go.transform.position = attachPoint.transform.position;

			joint = go.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
		}

		if (joint)
		{
			Vector3 dir = Vector3.Cross(Vector3.up, distance).normalized;
			float angle = Mathf.Acos(Vector3.Dot(Vector3.up, distance));
			Quaternion q = Quaternion.AxisAngle(dir, angle);
			Vector3 scale = new Vector3(0.1f, length * 0.5f, 0.1f);
			
			joint.transform.rotation = q;
			joint.transform.localScale = scale;
			joint.transform.position = ( left.position + right.position ) / 2;
			
			if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				var go = joint.gameObject;
				var rigidbody = go.GetComponent<Rigidbody>();
				Object.DestroyImmediate(joint);
				joint = null;
				Object.Destroy(go, 15.0f);
				rigidbody.velocity = distance.normalized * _speed;
			}
		}
	}    
}
