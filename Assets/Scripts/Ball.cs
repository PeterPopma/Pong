using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Ball : MonoBehaviour
{
    [SerializeField] Game game;
    Vector2 speed;
    Vector2 bottomLeft, topRight;

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
        float angle = Mathf.PI + 0.4f + Random.value * Mathf.PI * 0.7f;
        speed = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * 12.0f;
        game.PlayingGame = false;
    }

    void Update()
    {
        if (!game.PlayingGame)
        {
            return;
        }

        transform.position += new Vector3(speed.x, speed.y ,0) * Time.deltaTime;
        if (transform.position.x < bottomLeft.x || transform.position.x > topRight.x)
        {
            speed = new Vector2(-speed.x, speed.y);
        }
        if (transform.position.y < bottomLeft.y || transform.position.y > topRight.y)
        {
            speed = new Vector2(speed.x, -speed.y);
        }
        
        if (transform.position.x < -9)
        {
            game.IncreaseScore(1);
            InitializeBall();
        }

        if (transform.position.x > 9)
        {
            game.IncreaseScore(0);
            InitializeBall();
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        speed = new Vector2(-speed.x, speed.y);
    }

}
