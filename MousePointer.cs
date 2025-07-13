using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    private Camera cam;
    private Rigidbody rb;

    public float miX = -24.9f;
    public float maX = 18.4f;
    public float miY = -2.0f;
    public float maY = 3.4f;

    private Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        
        mouse.z = cam.WorldToScreenPoint(transform.position).z;

        Vector3 world = cam.ScreenToWorldPoint(mouse);

        world.x = Mathf.Clamp(world.x, miX, maX);
        world.y = Mathf.Clamp(world.y, miY, maY);

        Vector3 finalPos = Vector3.SmoothDamp(rb.position, world, ref vel, 0.1f);

        rb.MovePosition(finalPos);


    }
}
