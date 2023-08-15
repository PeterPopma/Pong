using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    bool upKeyPressed;
    bool downKeyPressed;
    [SerializeField] Ball ball;

    void Update()
    {
        Vector2 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        transform.position = new Vector3(bottomLeft.x + 0.22f, transform.position.y, 0);

        if (upKeyPressed && transform.position.y < 3.72f)
        {
            transform.Translate(new Vector3(0, 10f, 0) * Time.deltaTime);
        }

        if (downKeyPressed && transform.position.y > -3.72f)
        {
            transform.Translate(new Vector3(0, -10f, 0) * Time.deltaTime);
        }
    }

    private void OnUp(InputValue value)
    {
        if (value.isPressed) 
        {
            upKeyPressed = true;
        }
        else
        {
            upKeyPressed = false;
        }
    }

    private void OnDown(InputValue value)
    {
        if (value.isPressed)
        {
            downKeyPressed = true;
        }
        else
        {
            downKeyPressed = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (ball.Speed.x < 0)
        {
            ball.Speed = new Vector2(-ball.Speed.x, ball.Speed.y);
        }
    }

}
