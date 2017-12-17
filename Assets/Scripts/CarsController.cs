using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour {

    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject car1;
    private Rigidbody car1rb;
    public GameObject car2;
    private Rigidbody car2rb;
    public GameObject car3;

    private List<GameObject> cars1 = new List<GameObject>();
    private List<GameObject> cars2 = new List<GameObject>();

    private Vector3 zSpeed = new Vector3(0, 0, -10);
    private Vector3 xSpeed = new Vector3(-10, 0, 0);


    // Use this for initialization
    void Start () {

        InvokeRepeating("InstantiateCar1", 0, 1.0f);
        InvokeRepeating("InstantiateCar2", 0, 1.0f);

    }

    GameObject InstantiateCar1()
    {
        Quaternion spawn1Rotation = Quaternion.Euler(-90, 0, -270);
        GameObject car = (GameObject) Instantiate(car1, spawn1.transform);
        Rigidbody carRb = car.AddComponent<Rigidbody>();
        carRb.useGravity = false;
        car.transform.rotation = spawn1Rotation;
        cars1.Add(car);
        return car;
    }

    GameObject InstantiateCar2()
    {
        Quaternion spawn2Rotation = Quaternion.Euler(-90, 0, -180);
        GameObject car = (GameObject)Instantiate(car2, spawn2.transform);
        Rigidbody carRb = car.AddComponent<Rigidbody>();
        carRb.useGravity = false;
        car.transform.rotation = spawn2Rotation;
        cars2.Add(car);
        return car;
    }

    // Update is called once per frame
    void Update () {

        for(int i = 0; i < cars1.Count; i++)
        {
            if (cars1[i])
            {
                cars1[i].GetComponent<Rigidbody>().AddForce(zSpeed);

                if (cars1[i].transform.position.z < -50)
                {     
                    Destroy(cars1[i]);
                    //InstantiateCar(spawn1, cars1, spawn1Rotation);
                }
            }
        }

        for (int i = 0; i < cars2.Count; i++)
        {
            if (cars2[i])
            {
                cars2[i].GetComponent<Rigidbody>().AddForce(xSpeed);

                if (cars2[i].transform.position.x < -50)
                {
                    Destroy(cars2[i]);
                    // InstantiateCar(spawn2, cars2, spawn2Rotation);
                }
            }
        }


    }
}
