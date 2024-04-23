using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDisplay : MonoBehaviour
{
    public FirstPersonCamera FPC;
    public GameObject mainCam;
    public GameObject crosshair;

    public RawImage screen;
    public GameObject escapeButton;
    public GameObject approveButton;
    public GameObject denyButton;

    public Material screenDefault;
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
        approveButton.SetActive(true);
        denyButton.SetActive(true);
    }

    public void Escape()
    {
        mainCam.SetActive(true);
        StartCoroutine(ComputerTurnOffDelay());
        FPC.onComputer = false;
    }

    private IEnumerator ComputerTurnOffDelay()
    {
        yield return new WaitForSeconds(0.25f);
        screen.material = screenDefault;
        yield return new WaitForSeconds(0.25f);
        escapeButton.SetActive(false);
        approveButton.SetActive(false);
        denyButton.SetActive(false);
    }
}
