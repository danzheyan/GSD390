using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_mover : MonoBehaviour
{
    private Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        var ballMover = new ball_mover();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.zero;
    }
}
