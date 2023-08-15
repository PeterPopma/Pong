using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] Ball ball;

    void Update()
    {
        Vector2 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        transform.position = new Vector3(topRight.x - 0.22f, transform.position.y, 0);

        if (ball.transform.position.y > transform.position.y && transform.position.y < 3.72f)
        {
            transform.Translate(new Vector3(0, 5f, 0) * Time.deltaTime);
        }
        if (ball.transform.position.y < transform.position.y && transform.position.y > -3.72f)
        {
            transform.Translate(new Vector3(0, -5f, 0) * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (ball.Speed.x > 0)
        {
            ball.Speed = new Vector2(-ball.Speed.x, ball.Speed.y);
        }
    }
}
