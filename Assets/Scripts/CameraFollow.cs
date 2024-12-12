using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    // distance of camera from player
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = target.position - offset;
        
    }
}
