using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;

    public int points = 10;
    public float speed = 100f;

    private bool alreadyHit = false;
    private Vector2 direction;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = Random.insideUnitCircle.normalized;
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        Vector2 position = transform.localPosition;
        position += direction * speed * Time.deltaTime;

        if (position.x < -365f || position.x > 365f)
        {
            direction.x = -direction.x;
        }

        if (position.y < -202f || position.y > 202f)
        {
            direction.y = -direction.y;
        }

        transform.localPosition = position;
    }

    public void Setup(int newPoints, Color newColor)
    {
        points = newPoints;
        GetComponent<SpriteRenderer>().color = newColor;
    }

    private void OnMouseDown()
    {
        if (alreadyHit)
        {
            return;
        }
        alreadyHit = true;

        gameManager.AddScore(points);
        Destroy(gameObject);
    }
}
