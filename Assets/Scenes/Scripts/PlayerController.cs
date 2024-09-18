using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public string verticalInputAxis;
    public string horizontalInputAxis;
    public bool isPlayer1;

    private Rigidbody2D rb;
    private float halfFieldWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        halfFieldWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis(horizontalInputAxis) * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis(verticalInputAxis) * speed * Time.deltaTime;
        Vector2 newPosition = rb.position + new Vector2(moveHorizontal, moveVertical);

        newPosition.y = Mathf.Clamp(newPosition.y, -Camera.main.orthographicSize, Camera.main.orthographicSize);

        if (isPlayer1)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, -halfFieldWidth, 0);
        }
        else
        {
            newPosition.x = Mathf.Clamp(newPosition.x, 0, halfFieldWidth);
        }

        rb.MovePosition(newPosition);
    }
}