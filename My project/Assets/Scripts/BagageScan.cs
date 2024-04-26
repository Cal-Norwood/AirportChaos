using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagageScan : MonoBehaviour
{
    public Button approve;
    public Button deny;
    public int packageMoveForce;

    public List<GameObject> baggageInScanner;
    public BoxCollider checkPointCollider;
    public bool endOfConveyor = false;
    public ConveyorMoveRight CM;
    public Collider bagDetection;

    public GameObject processing;

    private int counter = 0;

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
            CM.conveyorSpeed = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            approve.interactable = true;
            deny.interactable = true;
            if(counter == 0)
            {
                baggageInScanner.Add(other.gameObject.transform.parent.gameObject);
            }
            else
            {
                foreach(GameObject g in baggageInScanner)
                {
                    if(other.gameObject.transform.parent.gameObject == g)
                    {
                        return;
                    }
                }
                baggageInScanner.Add(other.gameObject.transform.parent.gameObject);
            }
            counter++;
        }
    }

    public void Approve()
    {
        processing.SetActive(true);
        if (baggageInScanner.Count > 1)
        {
            approve.interactable = true;
            deny.interactable = true;
        }
        else
        {
            approve.interactable = false;
            deny.interactable = false;
        }
        CM.conveyorSpeed = 20;
        Physics.IgnoreCollision(bagDetection, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), false);
        StartCoroutine(PackageMoveUp());
    }

    public void Deny()
    {
        processing.SetActive(true);
        if (baggageInScanner.Count > 1)
        {
            approve.interactable = true;
            deny.interactable = true;
        }
        else
        {
            approve.interactable = false;
            deny.interactable = false;
        }
        CM.conveyorSpeed = 20;
        Physics.IgnoreCollision(bagDetection, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), false);
        StartCoroutine(PackageMoveDown());
    }

    private IEnumerator PackageMoveUp()
    {
        divider.GetComponent<ConveyorMoveForward>().enabled = true;
        while (endOfConveyor == false)
        {
            Physics.IgnoreCollision(checkPointCollider, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), true);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Physics.IgnoreCollision(checkPointCollider, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), false);
        baggageInScanner.Remove(baggageInScanner[0]);
        endOfConveyor = false;
    }

    private IEnumerator PackageMoveDown()
    {
        divider.GetComponent<ConveyorMoveBack>().enabled = true;
        while (endOfConveyor == false)
        {
            Physics.IgnoreCollision(checkPointCollider, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), true);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Physics.IgnoreCollision(checkPointCollider, baggageInScanner[0].GetComponentInChildren<BoxCollider>(), false);
        baggageInScanner.Remove(baggageInScanner[0]);
        endOfConveyor = false;
    }
}
