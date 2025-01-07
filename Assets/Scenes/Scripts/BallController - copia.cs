using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private int lastPlayerHit; // 1 para jugador 1, 2 para jugador 2
    [SerializeField]private float velocityMulriplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        LaunchBall();
    }
    private void Update()
    {
        Debug.Log(rb.velocity);
    }
    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x, y) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player1"))
        {
            lastPlayerHit = 1;
            rb.velocity *= velocityMulriplier;
            //rb.velocity += new Vector2(1,1);
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            lastPlayerHit = 2;
            rb.velocity *= velocityMulriplier;
            //rb.velocity += new Vector2(1, 1);
             
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
        else if (collision.gameObject.CompareTag("UpWall"))
        {
            var tmp = rb.velocity + new Vector2(0,1);
            rb.velocity = tmp.normalized * speed;
            //// La pelota rebota con las paredes
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
        else if (collision.gameObject.CompareTag("DownWall"))
        {
            var tmp = rb.velocity + new Vector2(0, 1);
            rb.velocity = tmp.normalized * speed;
            //// La pelota rebota con las paredes
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            var tmp = rb.velocity + new Vector2(1, 0);
            rb.velocity = tmp.normalized * speed;
            //// La pelota rebota con las paredes
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
        else if (collision.gameObject.CompareTag("LeftWall"))
        {
            var tmp = rb.velocity + new Vector2(1, 0);
            rb.velocity = tmp.normalized * speed;
            //// La pelota rebota con las paredes
            //Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            //rb.velocity = reflectDir * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            if (lastPlayerHit == 1)
            {
                gameManager.AddScore(1); // Player 1 scores
            }
            else if (lastPlayerHit == 2)
            {
                gameManager.AddScore(2); // Player 2 scores
            }
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }
}