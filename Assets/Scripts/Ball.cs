using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Ball : MonoBehaviour
{
    const float BALL_SPEED = 12.0f;
    [SerializeField] Game game;
    Vector2 speed;
    Vector2 bottomLeft, topRight;

    public Vector2 Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        InitializeBall();
    }

    private void InitializeBall()
    {
        transform.position = Vector3.zero;
        float angle = 0.2f + Random.value * Mathf.PI * 0.4f;
        speed = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * BALL_SPEED;
        game.PlayingGame = false;
    }

    void Update()
    {
        if (!game.PlayingGame)
        {
            return;
        }

        transform.position += new Vector3(speed.x, speed.y ,0) * Time.deltaTime;
        if (transform.position.y < bottomLeft.y || transform.position.y > topRight.y)
        {
            speed = new Vector2(speed.x, -speed.y);
            transform.position += new Vector3(speed.x, speed.y, 0) * Time.deltaTime;
        }

        if (transform.position.x < bottomLeft.x)
        {
            game.IncreaseScore(1);
            InitializeBall();
        }

        if (transform.position.x > topRight.x)
        {
            game.IncreaseScore(0);
            InitializeBall();
        }

        Debug.Log(speed.y);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {      
        SpeedIndicator speedIndicator = col.gameObject.GetComponent<SpeedIndicator>();
        if (speedIndicator != null)
        {
            if (speedIndicator.YSpeed > 0)
            {
                speed.y += BALL_SPEED * 0.15f;
                if (speed.y > BALL_SPEED - 0.1f)
                {
                    speed.y = BALL_SPEED - 0.1f;
                }

            }
            if (speedIndicator.YSpeed < 0)
            {
                speed.y -= BALL_SPEED * 0.15f;
                if (speed.y < -BALL_SPEED + 0.1f)
                {
                    speed.y = -BALL_SPEED + 0.1f;
                }
            }
            float xSpeed = Mathf.Sqrt(Mathf.Pow(BALL_SPEED, 2) - Mathf.Pow(Mathf.Abs(speed.y), 2));
            if (speed.x > 0) 
            {
                speed.x = xSpeed;
            }
            else
            {
                speed.x = -xSpeed;
            }
        }
    }

}
