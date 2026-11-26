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

        //every shoot (clicking left mouse button) produce a shooting sound.
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

        //choose one of the target types by chance and give the new target its points and color
        TargetType type = targetTypes[Random.Range(0, targetTypes.Length)];
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
