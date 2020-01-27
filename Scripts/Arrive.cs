using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : Seek {

    float maxSpeed;
    float slowRadius;

    float targetRadius;

    float timeToTarget = .1f;

    public virtual SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        float distance = result.linear.magnitude;

        if (distance < targetRadius)
        {
            return null;
        }

        if (distance > slowRadius)
        {
            result.linear.z = maxSpeed;
            return result;
        }
        else
        {
            result.linear.z = maxSpeed * (distance / slowRadius);

            Vector3 targetVelocity = new Vector3();
            targetVelocity = result.linear;
            targetVelocity.Normalize();
            targetVelocity *= result.linear.z;

            result.linear = targetVelocity - character.linearVelocity;
            result.linear /= timeToTarget;

            if(result.linear.magnitude > maxAcceleration)
            {
                result.linear.Normalize();
                result.linear *= maxAcceleration;
            }

            result.angular = 0;
            return result;
        }

        
    }
}
