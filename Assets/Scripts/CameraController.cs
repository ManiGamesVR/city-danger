using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float horizontalSpeed = 1.5f;
    private float verticalSpeed = 1.5f;

    public GameObject particle;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(-verticalSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(verticalSpeed, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -horizontalSpeed, 0);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, horizontalSpeed, 0);
            
        }

        if (Input.GetKey(KeyCode.E))
        {
            Vector3 mousePosition = Input.mousePosition;
            particle.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(
                mousePosition.x, mousePosition.y, 5f));

        }

        


    }
}
