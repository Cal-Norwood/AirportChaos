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
        
    }

    private void OnTriggerEnter(BoxCollider other)
    {
        if (other.tag == "Pickup")
        {
            Debug.Log("woking");
            endOfConveyor = false;
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
        while(endOfConveyor == true)
        {
            baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
            yield return null;
        }
    }

    private IEnumerator PackageMoveDown()
    {
        while (endOfConveyor == false)
        {
            baggageInScanner.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
            yield return null;
        }
    }

    private void OnTriggerEnter(SphereCollider other)
    {
        if (other.tag == "Pickup")
        {
            Debug.Log("woking");
            endOfConveyor = true;
        }
    }
}
