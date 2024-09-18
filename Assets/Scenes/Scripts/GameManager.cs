using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { None,OnPlay, OnPause, EndGame }
    public GameState currentState;

    public float gameTime = 180f; // 3 minutos
    public Text timerText;
    public Text player1ScoreText;
    public Text player2ScoreText;

    private float currentTime;
    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        currentState = GameState.OnPlay;
        currentTime = gameTime;
        UpdateScoreUI();
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.OnPlay:
                UpdateGameTime();
                break;
            case GameState.OnPause:
                // Lógica para el estado de pausa (si es necesario)
                break;
            case GameState.EndGame:
                // Lógica para el estado de fin de juego (si es necesario)
                break;
        }
    }

    void UpdateGameTime()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame();
        }
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Floor(currentTime).ToString();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1: " + player1Score.ToString();
        player2ScoreText.text = "Player 2: " + player2Score.ToString();
    }

    public void AddScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
        }
        else if (player == 2)
        {
            player2Score++;
        }
        UpdateScoreUI();
    }

    public void PauseGame()
    {
        currentState = GameState.OnPause;
        Time.timeScale = 0f; // Pausa el juego
    }

    public void ResumeGame()
    {
        currentState = GameState.OnPlay;
        Time.timeScale = 1f; // Reanuda el juego
    }

    void EndGame()
    {
        currentState = GameState.EndGame;
        // Aquí puedes añadir lógica para mostrar el ganador o reiniciar el juego
    }
}