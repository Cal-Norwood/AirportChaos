using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagageScan : MonoBehaviour
{
    public Button approve;
    public Button deny;
    public int packageMoveForce;

    public GameObject baggageInScanner;
    public BoxCollider checkPointCollider;
    public bool endOfConveyor = false;
    public ConveyorMoveRight CM;

    public GameObject processing;

    public GameObject divider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endOfConveyor == true)
        {
            divider.GetComponent<ConveyorMoveBack>().enabled = false;
            divider.GetComponent<ConveyorMoveForward>().enabled = false;
            CM.conveyorSpeed = 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            approve.interactable = true;
            deny.interactable = true;
            baggageInScanner = other.gameObject.transform.parent.gameObject;
        }
    }

    public void Approve()
    {
        processing.SetActive(true);
        approve.interactable = false;
        deny.interactable = false;
        CM.conveyorSpeed = 20;
        StartCoroutine(PackageMoveUp());
    }

    public void Deny()
    {
        processing.SetActive(true);
        approve.interactable = false;
        deny.interactable = false;
        CM.conveyorSpeed = 20;
        StartCoroutine(PackageMoveDown());
    }

    private IEnumerator PackageMoveUp()
    {
        divider.GetComponent<ConveyorMoveForward>().enabled = true;
        while (endOfConveyor == false)
        {
            Physics.IgnoreCollision(checkPointCollider, baggageInScanner.GetComponentInChildren<BoxCollider>(), true);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Physics.IgnoreCollision(checkPointCollider, baggageInScanner.GetComponentInChildren<BoxCollider>(), false);
        endOfConveyor = false;
    }

    private IEnumerator PackageMoveDown()
    {
        divider.GetComponent<ConveyorMoveBack>().enabled = true;
        while (endOfConveyor == false)
        {
            Physics.IgnoreCollision(checkPointCollider, baggageInScanner.GetComponentInChildren<BoxCollider>(), true);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Physics.IgnoreCollision(checkPointCollider, baggageInScanner.GetComponentInChildren<BoxCollider>(), false);
        endOfConveyor = false;
    }
}
