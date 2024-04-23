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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(endOfConveyor);
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
        checkPointCollider.isTrigger = true;
        StartCoroutine(PackageMoveUp());
    }

    public void Deny()
    {
        checkPointCollider.isTrigger = true;
        StartCoroutine(PackageMoveDown());
    }

    private IEnumerator PackageMoveUp()
    {
        while(endOfConveyor == false)
        {
            Debug.Log("woking");
            baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            yield return null;
        }

        baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        endOfConveyor = false;
        checkPointCollider.isTrigger = false;
    }

    private IEnumerator PackageMoveDown()
    {
        while (endOfConveyor == false)
        {
            baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            yield return null;
        }

        baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        endOfConveyor = false;
        checkPointCollider.isTrigger = false;
    }
}
