using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform vrCamera;

    private float rotationThreshold = 10f;
    private float rotationMax = 40f;
    private float movementSpeed = 3f;

    private bool moveForward = false;

	void Update () {
	    if (vrCamera.eulerAngles.x >= rotationThreshold && vrCamera.eulerAngles.x <= rotationMax)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }

        if (moveForward)
        {
            Vector3 moveDir = new Vector3(vrCamera.transform.forward.x, 0, vrCamera.transform.forward.z);
            transform.position += moveDir * Time.deltaTime * movementSpeed;
        }
	}
}
