using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMoveForward : MonoBehaviour
{
    private Rigidbody rb;
    public float conveyorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position -= transform.forward * conveyorSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.forward * conveyorSpeed * Time.deltaTime);
    }
}
