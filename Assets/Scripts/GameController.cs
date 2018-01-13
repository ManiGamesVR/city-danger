using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject startPoint;

	// Use this for initialization
	void Start () {
        player.transform.position = startPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
