using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopConveyorSideMovement : MonoBehaviour
{
    public BagageScan BS;
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
        BS.endOfConveyor = true;
    }
}
