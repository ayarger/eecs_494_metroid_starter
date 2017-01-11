using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EECS494FunBallController : MonoBehaviour {

    /* Inspector Tunables */
    public float acceleration_rate = 0.1f;

    // Function objects take the form of "delegates" in C#.
    // Should you wish to avoid the inconvenience of declaring a new
    // delegate data-type (as done in the line below), you can use an Action,
    // which is essentially a lambda.
    /* Action examples:
     * // Be sure to add "using System;" to your includes.
     * Action print_lambda = () => { print("Hello Action!"); };
     * Action<bool> a = (bool b) => { print("the bool's value is: " + b.ToString()); };
     */
    // - AY

    public delegate void VoidFunctionCollisionParam(Collision coll);

    // A list that contains all the listeners waiting for a collision event.
    public List<VoidFunctionCollisionParam> collision_callbacks = new List<VoidFunctionCollisionParam>();

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        // Lock ball to the x-y plane.
        // This can be done far easier in the inspector (Rigidbody component).
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        ProcessUserInput();
    }

    void ProcessUserInput()
    {
        Vector3 desired_acceleration = Vector3.zero;
        if (Input.GetKey(KeyCode.RightArrow))
            desired_acceleration += Vector3.right;
        if (Input.GetKey(KeyCode.LeftArrow))
            desired_acceleration += Vector3.left;

        rb.velocity += desired_acceleration * acceleration_rate;
    }

    /* Detect collision and report to listeners */
    void OnCollisionEnter(Collision collision)
    {
        foreach (VoidFunctionCollisionParam f in collision_callbacks)
            f(collision);
    }
}
