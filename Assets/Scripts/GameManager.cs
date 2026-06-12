using UnityEngine;
using TMPro;

public class NinjaGameManager : MonoBehaviour
{
    public static NinjaGameManager Instance;

    [Header("UI")]
    public TextMeshPro scoreText;
    public TextMeshPro livesText;
    public TextMeshPro timerText;

    [Header("Settings")]
    public float gameDuration = 60f;
    public int maxLives = 3;

    private int score = 0;
    private int lives;
    private float timeRemaining;
    private bool gameRunning = false;

    void Awake() => Instance = this;

    void Start()
    {
        lives = maxLives;
        timeRemaining = gameDuration;
        gameRunning = true;
        UpdateUI();
    }

    void Update()
    {
        if (!gameRunning) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0) EndGame();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();
        if (lives <= 0) EndGame();
    }

    void UpdateUI()
    {
        scoreText.text = "Score : " + score;
        livesText.text = "Vies : " + lives;
    }

    void EndGame()
    {
        gameRunning = false;
        scoreText.text = "Fini ! Score : " + score;
        FindFirstObjectByType<FruitSpawner>().StopSpawning();
    }
}