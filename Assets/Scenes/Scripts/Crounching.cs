using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crounching : MonoBehaviour
{
    [Header("Crounching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    public Rigidbody rb;

    public KeyCode crouchKey = KeyCode.LeftShift;

    [Header("CameraZoom")]

    private Camera cam;
    private float zoomFactor = 3f;
    private float targetZoom;
    private float startZoom;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startYScale = transform.localScale.y;

        targetZoom = cam.fieldOfView;
        startZoom = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        Crouching();
    }

    private void Crouching()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

            //change zoom

            targetZoom = 40;
            cam.fieldOfView = targetZoom;
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);

            //change zoom
            cam.fieldOfView = startZoom;
            targetZoom = 60;
        }
    }
}
