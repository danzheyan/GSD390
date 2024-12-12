using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMover : MonoBehaviour
{
    // script to move ball back and forth at different speeds
    // and change color based on location
    // uses properties, statics, and attributes
    // used for a collision obstacle in project (once I figure out collisions) :)
    // static int to keep track of the nuumber of ball instances
    public static int activeBallNum = 0;
    // organized control console in inspector allowing to adjust speed of ball and distance it moves
    // attributes make it easier to understand in inspector
    [Header("Controls")]
    [SerializeField, Tooltip("set speed of ball")] private float speed;
    [SerializeField, Tooltip("set distance ball moves")] private float maxDistance;
    //properties
    public float Speed
    {
        get { return speed; }
        // constraint so it can't be negative or zero speed
        set { speed = Mathf.Max(0.5f, value); }
    }
    public float MaxDistance
    {
        get { return maxDistance; }
        // constraint so it can't be negative or zero distance
        set { maxDistance = Mathf.Max(1f, value); }
    }
    private Vector3 startPosition;
    //change color of ball as it moves from start to end
    //private Color start = Color.yellow;
    //private Color end = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        //set the position, color, render object and add
        //an instance to static count of ball nums
        startPosition = transform.position;
        activeBallNum++;
        Debug.Log($"Active Balls: {activeBallNum}");
    }
    // Update is called once per frame
    void Update()
    {
        // move the ball back and forth between start and end, sin function works
        // anything better / changing speed at certain points?
        float oscillate = MaxDistance * Mathf.Sin(Time.time * Speed);
        transform.position = startPosition + new Vector3(0, 0, oscillate);
        // use linear interpolation to scale color based on distance of ball
        // from start to ends of oscillation
        float t = Mathf.Abs(oscillate / maxDistance);
        Debug.Log($"Location: {transform.position}");
    }

}
