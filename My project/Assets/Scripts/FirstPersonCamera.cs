using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public GameObject player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public bool onComputer = false;
    private bool freeMove = true;
    public GameObject computerCam;

    bool lockedCursor = true;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (onComputer == false && freeMove == true)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            player.transform.Rotate(Vector3.up * inputX);
        }
        else if (onComputer == true && freeMove == true)
        {
            freeMove = false;
            StartCoroutine(ComputerCamTransition());
        }

        if(onComputer == true)
        {
            player.transform.position = computerCam.transform.position;
        }

        if(onComputer == false && freeMove == false)
        {
            StartCoroutine(ComputerCamTransition());
        }
    }

    private IEnumerator ComputerCamTransition()
    {
        if(onComputer == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            player.transform.position = computerCam.transform.position;
            computerCam.SetActive(true);
            gameObject.SetActive(false);
            yield return 0;
        }
        else
        {
            freeMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            computerCam.SetActive(false);
            yield return 0;
        }
    }
}
