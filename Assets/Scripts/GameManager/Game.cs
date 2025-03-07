using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player; 
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EnemySpawner _enemySpawner;

    private Enemy _enemy;

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += OnSetEnemy;
        _enemySpawner.EnemyRemoved += _scoreCounter.AddScore;
        _startScreen.ButtonClicked += OnStartButtonClick;
        _endScreen.ButtonClicked += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= OnSetEnemy;
        _enemySpawner.EnemyRemoved -= _scoreCounter.AddScore;
        _startScreen.ButtonClicked -= OnStartButtonClick;
        _endScreen.ButtonClicked -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnSetEnemy(Enemy enemy)
    {
        _enemy = enemy;
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
