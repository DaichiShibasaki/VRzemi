using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shottest : MonoBehaviour {
    
	public GameObject prefab;
	public Rigidbody attachPoint;
    public Transform Backward;
	[SerializeField] float _speed = 100;
	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
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

            Vector3 forward = attachPoint.transform.position - Backward.position;

			rigidbody.velocity = forward * _speed;

			rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
	}
}
