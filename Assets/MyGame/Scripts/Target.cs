using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;

    
    public int points = 10;

   
    private bool alreadyHit = false;

    private void Start()
    {
       
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 2f);
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
