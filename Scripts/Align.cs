using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour {

    public Kinematic character; // pulibc? what's the matter with you?
    public GameObject target; // shut it I'm just trying to get this working ye great ape

    float maxAngularAcceleration;
    float maxRotation;

    float targetRadius;

    float targetRotation;

    float slowRadius;

    float timeToTarget = .1f;

    public SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.angular = target.transform.rotation.y - character.angularVelocity;

        result.angular = Mathf.DeltaAngle(Mathf.PI, -Mathf.PI);
        float rotationSize = Mathf.Abs(result.angular);

        if(rotationSize < targetRadius)
        {
            return null;
        }

        if (rotationSize > slowRadius)
        {
            targetRotation = maxRotation;
        }
        else
        {
            targetRotation = maxRotation * (rotationSize / slowRadius);
        }

        targetRotation *= result.angular / rotationSize;

        result.angular = targetRotation - character.angularVelocity;

        result.angular /= timeToTarget;

        float angularAcceleration = Mathf.Abs(result.angular);
        if(angularAcceleration > maxAngularAcceleration)
        {
            result.angular /= angularAcceleration;
            result.angular *= maxAngularAcceleration;
        }

        result.linear = Vector3.zero;
        return result;
        
    }
}
