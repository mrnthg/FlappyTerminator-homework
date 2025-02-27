using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player; 
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private ScoreCounter _scoreCounter;
 
    private Enemy _enemy;

    private void OnEnable()
    {
        _startScreen.StartButtonClicked += OnStartButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClicked -= OnStartButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    public void Init(Enemy enemy)
    {
        _enemy = enemy;
        _scoreCounter.SetEnemy(enemy);
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _enemy.ResetEnemy();
        _scoreCounter.Reset(); 
    }
}
