using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align {

    SteeringOutput target;
    Vector3 direction;

    public virtual SteeringOutput GetSteering()
    {
        direction = target.linear - character.transform.position;

        if (direction.magnitude == 0)
        {
            return target;
        }
        //target = explicitTarget; //I don't know what this line does
        target.angular = Mathf.Atan2(-direction.x, direction.z);
        return GetSteering();
    }
}
