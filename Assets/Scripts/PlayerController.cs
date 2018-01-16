using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public List<GameObject> sources;
    public List<GameObject> targets;
    public GameObject finish;
    public Transform vrCamera;
    public List<GameObject> peopleZones;

    private int currentTeleport = 0;
    private int lastTeleport;
    private float rotationThreshold = 10f;
    private float rotationMax = 40f;
    private float movementSpeed = 6f;

    private bool moveForward = false;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lastTeleport = sources.Count;
        peopleZones[0].SetActive(true);
    }

    void Update () {

        rigidbody.velocity = Vector3.zero;
        
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Teleporter"))
        {
            transform.position = new Vector3(targets[currentTeleport].transform.position.x, transform.position.y, targets[currentTeleport].transform.position.z);
            currentTeleport++;
            peopleZones[currentTeleport - 1].SetActive(false);
            if (currentTeleport < peopleZones.Count)
                peopleZones[currentTeleport].SetActive(true);
        }
    }
}
