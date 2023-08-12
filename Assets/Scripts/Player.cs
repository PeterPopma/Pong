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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (upKeyPressed && transform.position.y < 3.17f)
        {
            transform.Translate(new Vector3(0, 0.3f, 0));
        }

        if (downKeyPressed && transform.position.y > -3.15f)
        {
            transform.Translate(new Vector3(0, -0.3f, 0));
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

}
