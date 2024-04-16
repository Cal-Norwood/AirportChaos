using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float mouseSensitivity;
    private float xAxisCLamp = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisCLamp -= gameObject.transform.rotation.x;

        Vector3 rotPlayer = gameObject.transform.rotation.eulerAngles;

        rotPlayer.y += rotAmountX;
        rotPlayer.x += rotAmountY;

        if (xAxisCLamp > 90)
        {
            xAxisCLamp = 89;
        }
        else if (xAxisCLamp < -90)
        {
            xAxisCLamp = -89;
        }

        gameObject.transform.rotation = Quaternion.Euler(rotPlayer);
    }
}
