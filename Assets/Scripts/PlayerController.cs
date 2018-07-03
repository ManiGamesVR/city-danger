using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    public Transform vrCamera;

    private float rotationThreshold = 30f;
    private float rotationMax = 90f;
    private float movementSpeed = 3f;

    private bool moveForward = false;

    private CharacterController characterController;

	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
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
            Vector3 fwd = vrCamera.TransformDirection(Vector3.forward);
            characterController.SimpleMove(fwd * movementSpeed);
        }
	}
}
