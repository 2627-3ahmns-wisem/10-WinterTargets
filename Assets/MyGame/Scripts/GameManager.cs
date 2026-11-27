using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject winSprite;
    public Text scoreText;

    public int winScore = 100;

    public TargetType[] targetTypes =
    {
        new TargetType("Schneemann", 10, Color.white),
        new TargetType("Geschenk", 20, new Color(1f, 0.35f, 0.35f)),
        new TargetType("Eisblock", -10, new Color(0.45f, 0.8f, 1f))
    };

    private int score = 0;
    private bool win = false;

    private void Start()
    {
        InvokeRepeating("Spawn",1f,1f);
    }

    private void Update()
    {
        
        if(win)
        {
            CancelInvoke("Spawn");
        }

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(-365f, 365f);
        float randomY = Random.Range(-202f,202f);

        Vector2 random2DPosition = new Vector2(randomX, randomY);

        GameObject newTarget = Instantiate(target, parentOfTargets.transform);
        newTarget.transform.localPosition = random2DPosition;

        int roll = Random.Range(0, 100);
        TargetType type;

        if (roll < 60)
        {
            type = targetTypes[0];
        }
        else if (roll < 90)
        {
            type = targetTypes[2];
        }
        else
        {
            type = targetTypes[1];
        }

        newTarget.GetComponent<Target>().Setup(type.points, type.color);
    }

    public void AddScore(int value)
    {
        score += value;
        print(score);

        scoreText.text = score.ToString();

        if (score >= winScore)
        {
            win = true;
            winSprite.SetActive(true);
        }
    }
}
