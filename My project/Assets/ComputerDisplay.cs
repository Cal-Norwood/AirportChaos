using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDisplay : MonoBehaviour
{
    public FirstPersonCamera FPC;
    public GameObject crosshair;

    public RawImage screen;
    public GameObject escapeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FPC.onComputer == false)
        {
            crosshair.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                crosshair.SetActive(false);
                FPC.onComputer = true;
                StartCoroutine(Load());
            }
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        screen.material = null;
        escapeButton.SetActive(true);
    }
}
