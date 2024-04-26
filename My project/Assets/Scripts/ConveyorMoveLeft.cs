using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMoveLeft : MonoBehaviour
{
    private Rigidbody rb;
    public float conveyorSpeed;

    public bool packageApproved;
    public bool packageDenied;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position -= transform.right * conveyorSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.right * conveyorSpeed * Time.deltaTime);
    }
}
