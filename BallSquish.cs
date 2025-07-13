using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSquish : MonoBehaviour
{
    public Collider[] colliders;      

    private Vector3 original;               
    private Vector3 last;    
    private Rigidbody rb;                 

    void Start()
    {
        original = transform.localScale;    
        rb = GetComponent<Rigidbody>();   
        last = rb.position;  
    }

    void FixedUpdate()
    {
        bool nearWall = false;
        foreach (Collider collider in colliders)
        {
            Vector3 closest = collider.ClosestPoint(rb.position);
            float distance = Vector3.Distance(rb.position, closest);

            if (distance <= 1.0f)
            {
                SquishBall(collider, closest, distance);
                nearWall = true;
                break;  
            }
        }
        if (nearWall)
        {
            rb.MovePosition(last);  
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, original, Time.deltaTime * 5.0f);
            last = rb.position;
        }
    }

    private void SquishBall(Collider collider, Vector3 closest, float distance)
    {
        rb.MovePosition(last);
        Vector3 squish = original;  
        float squishAmount = Mathf.Lerp(1.0f, 0.5f, 1.0f - distance);
        if (!FloorOrCeiling(collider))
        {
            squish.x = Mathf.Lerp(transform.localScale.x, original.x * squishAmount / 2.0f, Time.deltaTime * 5.0f);
        }
        else
        {
            squish.y = Mathf.Lerp(transform.localScale.y, original.y * squishAmount / 2.0f, Time.deltaTime * 5.0f);

        }

        transform.localScale = squish;
    }

    private bool FloorOrCeiling(Collider collider)
    {
        return collider.gameObject.name == "Cube" || collider.gameObject.name == "Cube (1)";
    }
}
