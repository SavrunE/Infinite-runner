using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Quaternion OriginRotation;
    float Angle;
    private void Start()
    {
        OriginRotation = transform.rotation; 
    }
    void FixedUpdate()
    {
        Angle++;
        Quaternion RotationY = Quaternion.AngleAxis(Angle + 1, Vector3.up);
        Quaternion RotationZ = Quaternion.AngleAxis(Angle, Vector3.back);
        //Quaternion RotationY = Quaternion.AngleAxis(2, Vector3.up);
        //Quaternion RotationZ = Quaternion.AngleAxis(2, Vector3.back);
        //transform.rotation *= RotationY * RotationZ;
        transform.rotation = OriginRotation * RotationY * RotationZ;
    }
}
