using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    private float x;
    private float y;
    public float speed;
    public bool isGrounded = false;
    public float jumpForce;

    public FirstPersonCamera FPC;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if(FPC.onComputer == false)
        {
            rb.AddForce((x * transform.right + y * transform.forward) * speed, ForceMode.VelocityChange);
        }
    }

    void Jump()
    {
        if(FPC.onComputer == false)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
