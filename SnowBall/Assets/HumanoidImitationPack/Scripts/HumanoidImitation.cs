using UnityEngine;
using System.Collections;

public class HumanoidImitation : MonoBehaviour
{
    private bool isUpdated = false;
    private Vector3 mLastCamPos;
    private Quaternion mLastCamRot;

    public GameObject head;
    public GameObject bodyIKTarget;
    void Start()
    {
        isUpdated = false;
        mLastCamPos = Camera.main.transform.position;
        mLastCamRot = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        isUpdated = false;

        head.transform.rotation = Camera.main.transform.rotation;

        Vector3 rValue = new Vector3(0.0f, 180.0f, 0.0f);
        head.transform.Rotate(rValue, Space.World);

        // カメラ位置変化量の適用
        Vector3 diff = Camera.main.transform.position - mLastCamPos;
        diff = new Vector3(diff.x, diff.y, -diff.z);
        if (bodyIKTarget)
        {
            bodyIKTarget.transform.position += diff;
            mLastCamPos = Camera.main.transform.position;
            bodyIKTarget.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
