using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScript : MonoBehaviour {
    public GameObject[] hoverPoints;
    public float desiredHeight = 0.2f;
    public float hoverForce = 3f;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }
    
    private void FixedUpdate()
    {
        foreach(GameObject hoverPoint in hoverPoints)
        {
            RaycastHit hit;
            if (Physics.Raycast(hoverPoint.transform.position, -hoverPoint.transform.up, out hit, desiredHeight )) {
                float forceToApply = hoverForce * (1f - (hit.distance / desiredHeight));
                rb.AddForceAtPosition(Vector3.up * forceToApply, hoverPoint.transform.position);
            }
        }
    }
}
