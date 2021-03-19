using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    float xRot=0f, yRot = 0f;
    public Rigidbody ball;
    public float rotationSpeed = 5f;
    public float shootPower = 60f;
    public Transform tower;
    public GameObject Raycast;
    public GameObject CameraMove;
    public Button yourButton;
    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(pointerUp);
    }
    void Update ()
    {
        transform.position = ball.position;
        if (Input.GetMouseButton(0))
        {
            Raycast.GetComponent<RaycastReflection>().working();
            xRot += Input.GetAxis("Mouse X") * rotationSpeed;
            tower.localRotation = Quaternion.AngleAxis(xRot, Vector3.up);

            yRot += Input.GetAxis("Mouse Y") * rotationSpeed * -Time.deltaTime;
            if (yRot < -5f & yRot > 0f)
            {
                yRot = -5f;
            }
            transform.rotation = Quaternion.Euler(yRot, xRot, 0f);
        }
        if (tower.position.x != 2.15f)
        {
            CameraMove.GetComponent<CameraFollw>().moving();
        }
    }
    public void pointerUp()
    {
        ball.velocity = transform.forward * shootPower;
    }
}
