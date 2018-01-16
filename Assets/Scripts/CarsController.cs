using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsController : MonoBehaviour {

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject[] cars = new GameObject[3];

    private Random random;
    private List<GameObject> cars1 = new List<GameObject>();
    private List<GameObject> cars2 = new List<GameObject>();

    private Vector3 zSpeed = new Vector3(0, 0, 5);
    private Vector3 xSpeed = new Vector3(-5, 0, 0);


    // Use this for initialization
    void Start () {
        random = new Random();
        InvokeRepeating("InstantiateCar1", 0, 2.0f);
        InvokeRepeating("InstantiateCar2", 0, 2.0f);

    }

    GameObject InstantiateCar1()
    {
        Quaternion spawn1Rotation = Quaternion.Euler(-90, 180, -270);
        GameObject car = (GameObject) Instantiate(cars[(int)Random.Range(0, 2.99f)], spawn1.transform);
        Rigidbody carRb = car.AddComponent<Rigidbody>();
        carRb.useGravity = false;
        car.transform.rotation = spawn1Rotation;
        cars1.Add(car);
        return car;
    }

    GameObject InstantiateCar2()
    {
        Quaternion spawn2Rotation = Quaternion.Euler(-90, 0, -270);
        GameObject car = (GameObject)Instantiate(cars[(int)Random.Range(0, 2.99f)], spawn2.transform);
        Rigidbody carRb = car.AddComponent<Rigidbody>();
        carRb.useGravity = false;
        car.transform.rotation = spawn2Rotation;
        cars2.Add(car);
        return car;
    }

    // Update is called once per frame
    void Update () {

        updateCars(cars1, zSpeed, 'z', 500);
        updateCars(cars2, -zSpeed, 'z', 500);
    }

    void updateCars(List<GameObject> cars, Vector3 force, char axis, int threshold)
    {
        for (int i=0; i < cars.Count; i++)
        {
            if (cars[i])
            {
                cars[i].GetComponent<Rigidbody>().AddForce(force);
                int absThreshold = Mathf.Abs(threshold);
                switch (axis)
                {
                    case 'x':
                        if (Mathf.Abs(cars[i].transform.position.x) > absThreshold)
                            Destroy(cars[i]);
                        break;
                    case 'y':
                        if (Mathf.Abs(cars[i].transform.position.y) > absThreshold)
                            Destroy(cars[i]);
                        break;
                    case 'z':
                        if (Mathf.Abs(cars[i].transform.position.z) > absThreshold)
                            Destroy(cars[i]);
                        break;

                }

            }
        }
    }
}
