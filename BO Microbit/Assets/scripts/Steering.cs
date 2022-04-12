using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    //public GameObject gameObject;
    public bool isFlat = true;
    int Axis;

    Rigidbody rigidbody;
    float Speed;

    private ReadMicrobit ReadMicrobit;
    //private Rigidbody steering;
    // Start is called before the first frame update
    void Awake()
    {
        ReadMicrobit = GetComponent<ReadMicrobit>();
    }
    //get component steering in microbit 
    //set x and y value in steering
    //buttons
    //search get component on yt

    private void Start()
    {
        Debug.Log("hi");
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 90) * tilt;
        Debug.Log("tilt");
        Debug.DrawRay(transform.position + Vector3.up, tilt);

        rigidbody = GetComponent<Rigidbody>();
        Speed = 10.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        rigidbody.AddForce(transform.right * 200); //speed of car
        rigidbody.useGravity = true; //gravity

        transform.rotation = Quaternion.Euler(0, ReadMicrobit.yAxis * 0.5f, 0); //steering rotation force on y-axis
        /*
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = transform.forward * Speed;
        }

        if (Axis <= 200)
        {
            transform.position = new Vector3(0,Axis,0) * Time.deltaTime;
        }
            //steering.AddForce(Input.acceleration);
        */
        //if (ReadMicrobit.yAxis != null)
    }
}
