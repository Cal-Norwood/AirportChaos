using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMove : MonoBehaviour
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
        rb.position -= -transform.right * conveyorSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + -transform.right * conveyorSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("woking");
    }
}
