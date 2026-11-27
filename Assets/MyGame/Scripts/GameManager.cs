using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject winSprite;
    public Text scoreText;

    public float roundTime = 60f;
    public int winScore = 100;

    public TargetType[] targetTypes =
    {
        new TargetType("Schneemann", 10, Color.white),
        new TargetType("Geschenk", 20, new Color(1f, 0.35f, 0.35f)),
        new TargetType("Eisblock", -10, new Color(0.45f, 0.8f, 1f))
    };

    private int score = 0;
    private float timeLeft = 0f;
    private bool gameRunning = false;

    private void Start()
    {
        scoreText.horizontalOverflow = HorizontalWrapMode.Overflow;
        scoreText.verticalOverflow = VerticalWrapMode.Overflow;
        scoreText.alignment = TextAnchor.UpperCenter;
        StartRound();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (gameRunning)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                EndRound();
            }
            else
            {
                ShowScore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartRound();
        }
    }

    private void StartRound()
    {
        foreach (Target oldTarget in FindObjectsByType<Target>(FindObjectsSortMode.None))
        {
            Destroy(oldTarget.gameObject);
        }

        score = 0;
        timeLeft = roundTime;
        gameRunning = true;
        winSprite.SetActive(false);
        ShowScore();

        InvokeRepeating("Spawn", 1f, 1f);
    }

    private void EndRound()
    {
        gameRunning = false;
        CancelInvoke("Spawn");

        if (score >= winScore)
        {
            winSprite.SetActive(true);
        }

        scoreText.text = score + "\n<size=30>Ende</size>";
    }

    private void ShowScore()
    {
        scoreText.text = score + "\n<size=30>" + Mathf.CeilToInt(timeLeft) + " s</size>";
    }

    private void Spawn()
    {
        float randomX = Random.Range(-365f, 365f);
        float randomY = Random.Range(-202f, 202f);

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
        if (!gameRunning)
        {
            return;
        }

        score += value;
        ShowScore();
    }
}
