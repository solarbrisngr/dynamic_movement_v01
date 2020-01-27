using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    public Vector3 linearVelocity;
    public float angularVelocity;  // Millington calls this rotation
    // because I'm attached to a gameobject, we also have:
    // rotation <<< Millington calls this orientation
    // position

    public GameObject myTarget;

    // Update is called once per frame
    void Update()
    {
        // update my position and rotation
        this.transform.position += linearVelocity * Time.deltaTime;
        Vector3 v = new Vector3(0, angularVelocity, 0); // TODO - don't make a new Vector3 every update you silly person
        this.transform.eulerAngles += v * Time.deltaTime;

        // update linear and angular velocities
        SteeringOutput steering = new SteeringOutput();

        //Seek mySeek = new Seek();
        //mySeek.character = this;
        //mySeek.target = myTarget;
        //steering = mySeek.getSteering();
        //linearVelocity += steering.linear * Time.deltaTime;
        //angularVelocity += steering.angular * Time.deltaTime;

        Arrive myArrive = new Arrive();
        myArrive.character = this;
        myArrive.target = myTarget;
        steering = myArrive.getSteering();
        if (steering != null)
        {
            linearVelocity += steering.linear * Time.deltaTime;
            angularVelocity += steering.angular * Time.deltaTime;
        }
        else
        {
            linearVelocity = Vector3.zero;
        }

        //Align myAlign = new Align();
        //myAlign.character = this;
        //myAlign.target = myTarget;
        //steering = myAlign.getSteering();
        //if (steering != null)
        //{
        //    linearVelocity += steering.linear * Time.deltaTime;
        //    angularVelocity += steering.angular * Time.deltaTime;
        //}
    }

    // a stub to test my update function. In the future we will call getSteering on different dynamic steering behavior classes
    //SteeringOutput getSteering()
    //{
    //    SteeringOutput  steering = new SteeringOutput();
    //    steering.linear.z = 0;
    //    steering.angular = 1;
    //    return steering;
    //}


}
