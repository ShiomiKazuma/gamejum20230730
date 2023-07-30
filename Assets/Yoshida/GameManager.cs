using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>敵のキル数</summary>
    int _enemyKillCount = 0;
    /// <summary>敵のキル数ゲッター</summary>
    public int EnemyKillCount => _enemyKillCount;
    /// <summary>ゲームの経過時間</summary>
    float _timer = 0;
    /// <summary>ゲームの経過時間ゲッター</summary>
    public float Timer => _timer;
    [SerializeField, Header("スコアの倍率")] float _scoreScale = 10;

    /// <summary>ゲームオーバー時に表示されるテキスト</summary>
    [SerializeField] GameObject _gameOverText;
    /// <summary>ゲームクリアー時に表示されるテキスト</summary>
    [SerializeField] GameObject _gameClearText;
    /// <summary>ゲームポーズ時に表示されるテキスト</summary>
    [SerializeField] GameObject _gamePausedText;

    /// <summary>タイトルボタン</summary>
    [SerializeField] GameObject _titleButton;
    /// <summary>リトライボタン</summary>
    [SerializeField] GameObject _reTryButton;
    /// <summary>ポーズボタン</summary>
    [SerializeField] GameObject _pauseButton;
    /// <summary>ゲーム経過時間テキスト</summary>
    [SerializeField] Text _timerText;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum PlayerState
    {
        Dead,
        Alive,
    }

    public enum GameState
    {
        GameOver,
        GameClear,
        GamePaused,
    }

    void Start()
    {
        _gameOverText.SetActive(false);
        _gameClearText.SetActive(false);
        _gamePausedText.SetActive(false);
        
        _titleButton.SetActive(false);
        _reTryButton.SetActive(false);
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    public void GameStateProcess(GameState state)
    {
        switch (state)
        {
            case GameState.GameOver : GameOver();
                break;

            case GameState.GameClear : GameClear();
                break;

            case GameState.GamePaused : GamePaused();
                break;
        }
    }

    /// <summary>ゲームオーバー時の処理</summary>
    void GameOver()
    {
        _gameOverText.SetActive(true);
        _reTryButton.SetActive(true);
        print("GameOver");
    }

    /// <summary>ゲームクリアー時の処理</summary>
    void GameClear()
    {
        _gameClearText.SetActive(true);
        _titleButton.SetActive(true);
        print("GameClear");
    }

    /// <summary>ゲームポーズ時の処理</summary>
    void GamePaused()
    {
        _gamePausedText.SetActive(true);
        _titleButton.SetActive(true);
        Time.timeScale = 0;
        print("GamePaused");
    }

    /// <summary>スコアを計算するメソッド</summary>
    /// <param name="time">クリアタイムを入れる</param>
    /// <param name="killCount">敵のキル数を入れる</param>
    /// <returns>計算した合計スコアを返す</returns>
    public float Score(float time, float killCount)
    {
        float score = 0;
        score += time * _scoreScale;
        score += killCount * _scoreScale;
        return score;
    }
}
