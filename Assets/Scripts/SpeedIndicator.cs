using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIndicator : MonoBehaviour
{
    float ySpeed;
    float previousYposition;

    public float YSpeed { get => ySpeed; set => ySpeed = value; }

    protected void FixedUpdate()
    {
        ySpeed = transform.position.y - previousYposition;
        previousYposition = transform.position.y;
    }
}
