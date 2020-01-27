using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereYoureGoing : Align {

    public virtual SteeringOutput GetSteering()
    {
        Vector3 velocity = character.linearVelocity;

        if (velocity.magnitude == 0)
        {
            return null;
        }

        float tempRot = Mathf.Atan2(-velocity.x, velocity.z);
        float newRot = Mathf.Rad2Deg * tempRot;

        target.transform.rotation = Quaternion.Euler(0,newRot,0);
        return GetSteering();
    }
}
