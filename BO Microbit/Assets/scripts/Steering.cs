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

    private void Start()
    {
        Debug.Log("hi");
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(0, 0, 90) * tilt;
        Debug.Log("tilt");
        Debug.DrawRay(transform.position + Vector3.up, tilt);

        rigidbody = GetComponent<Rigidbody>();
        Speed = 10.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (ReadMicrobit.ButtonPressed)
        {
            rigidbody.AddForce(transform.right * 75); //speed of car

        }
        if (ReadMicrobit.ButtonPressedB)
        {
            rigidbody.AddForce(transform.right * -50); //speed of car

        }

        transform.rotation = Quaternion.Euler(0, ReadMicrobit.xAxis * 0.5f, 0); //steering rotation force on y-axis
       
    }
}
