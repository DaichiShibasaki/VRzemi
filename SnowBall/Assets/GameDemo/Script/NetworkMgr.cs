using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkMgr : MonoBehaviour {
    public GameObject objectPrefab;
    string ip = "172.18.10.129";
    string port = "1192";
    bool connected = false;

    public void OnConnectedToServer()
    {
        connected = true;
    }

    public void OnServerInitialized()
    {
        connected = true;

    }


    public void OnGUI()
    {
        if (!connected)
        {
            if (GUI.Button(new Rect(10, 10, 90, 90), "Client"))
            {
                Network.Connect(ip, int.Parse(port));
            }
            if (GUI.Button(new Rect(10, 110, 90, 90), "Master"))
            {
                Network.InitializeServer(10, int.Parse(port), false);
            }
        }
    }
}
