using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjectRB;

    public float pickupRange;
    public float pickupForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    if(hit.transform.gameObject.tag == "Pickup")
                    {
                        PickupObject(hit.transform.gameObject);
                    }  
                }
            }
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            if(heldObj != null)
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
            {
                Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
                heldObjectRB.AddForce(moveDirection * pickupForce);
            }
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            heldObjectRB = pickObj.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.drag = 10;

            heldObjectRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjectRB.useGravity = true;
        heldObjectRB.drag = 0;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
