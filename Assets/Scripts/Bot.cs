using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] Ball ball;

    void FixedUpdate()
    {
        if (ball.transform.position.y > transform.position.y && transform.position.y < 3.17f)
        {
            transform.Translate(new Vector3(0, 0.1f, 0));
        }
        if (ball.transform.position.y < transform.position.y && transform.position.y > -3.17f)
        {
            transform.Translate(new Vector3(0, -0.1f, 0));
        }
    }
}
