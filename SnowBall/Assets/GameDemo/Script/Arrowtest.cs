﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowtest : MonoBehaviour {

    [SerializeField] Transform left = null; //Controller (left)
    [SerializeField] Transform right = null; //Controller (right)
    [SerializeField] SteamVR_TrackedObject arrow_controller = null; //Controller (right)
    [SerializeField] SteamVR_TrackedObject bow_controller = null; //Controller (left)
    [SerializeField] float _speed = 100;
	public GameObject prefab;
	public Rigidbody attachPoint;
	FixedJoint joint;
    
	const ushort DRAW_VIVE_POW = 1000;
	const ushort SHOT_VIVE_POW = 3999;
	float _vive_length = 0;
	public float _before_length = 0;
	const float VIVE_LENGTH = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)arrow_controller.index);
        Vector3 distance = right.position - left.position;
        float length = distance.magnitude;
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && length < 0.2f)
		{
			var go = GameObject.Instantiate(prefab);
			go.transform.position = attachPoint.transform.position;

			joint = go.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
			_vive_length = length - VIVE_LENGTH;
			_before_length = length;
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
			
			//バイブレーション
			if ( length > _vive_length ) {
				device.TriggerHapticPulse(DRAW_VIVE_POW);
				SteamVR_Controller.Input((int)bow_controller.index).TriggerHapticPulse(DRAW_VIVE_POW);
				_vive_length += VIVE_LENGTH;
				_before_length = length;
			}

			if ( length - _before_length < -0.1 ) {
				_vive_length = length;
				_before_length = length;
			}


			if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
			{
				var go = joint.gameObject;
				var rigidbody = go.GetComponent<Rigidbody>();
				go.AddComponent<Arrow> ();
				Object.DestroyImmediate(joint);
				joint = null;
				Object.Destroy(go, 15.0f);
				rigidbody.velocity = distance.normalized * _speed;
				
				//バイブレーション
				device.TriggerHapticPulse(SHOT_VIVE_POW);
				SteamVR_Controller.Input((int)bow_controller.index).TriggerHapticPulse(SHOT_VIVE_POW);
			}
		} else {
			_vive_length = 0;
			_before_length = 0;
		}
	}    
}
