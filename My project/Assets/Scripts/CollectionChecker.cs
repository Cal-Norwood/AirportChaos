using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionChecker : MonoBehaviour
{
    public RoundManager RM;
    public BagageScan BS;

    public bool denySide = false;
    public bool incineratorSide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BS.processing.SetActive(false);
        if (denySide == false && incineratorSide == false)
        {
            if (other.gameObject.transform.parent.gameObject.layer == 10)
            {
                RM.GreenProgress();
            }

            if (other.gameObject.transform.parent.gameObject.layer == 11)
            {
                RM.RedProgress();
            }
        }
        else if (denySide == true && incineratorSide == true)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
            if (other.gameObject.transform.parent.gameObject.layer == 11)
            {
                RM.GreenProgress();
            }

            if (other.gameObject.transform.parent.gameObject.layer == 10)
            {
                RM.RedProgress();
            }
        }
    }
}
