using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPop : MonoBehaviour {


    GameObject Player;
    public GameObject PlayerPrefab;
    public Transform startpoint1;
    public Transform startpoint2;


    // Use this for initialization
    void Start () {
	}

    private void OnServerInitialized()
    {
        Player = Network.Instantiate(PlayerPrefab, startpoint1.position, startpoint1.rotation, 0) as GameObject;
        Debug.Log("Server");
    }
    private void OnConnectedToServer()
    {
        Player = Network.Instantiate(PlayerPrefab, startpoint2.position, startpoint2.rotation, 0) as GameObject;
        Debug.Log("Client");
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
