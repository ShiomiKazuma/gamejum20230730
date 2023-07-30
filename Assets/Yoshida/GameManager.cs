using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>�G�̃L����</summary>
    int _enemyKillCount = 0;
    /// <summary>�G�̃L�����Q�b�^�[</summary>
    public int EnemyKillCount => _enemyKillCount;
    /// <summary>�Q�[���̌o�ߎ���</summary>
    float _timer = 0;
    /// <summary>�Q�[���̌o�ߎ��ԃQ�b�^�[</summary>
    public float Timer => _timer;
    [SerializeField, Header("�X�R�A�̔{��")] float _scoreScale = 10;

    /// <summary>�Q�[���I�[�o�[���ɕ\�������e�L�X�g</summary>
    [SerializeField] GameObject _gameOverText;
    /// <summary>�Q�[���N���A�[���ɕ\�������e�L�X�g</summary>
    [SerializeField] GameObject _gameClearText;
    /// <summary>�Q�[���|�[�Y���ɕ\�������e�L�X�g</summary>
    [SerializeField] GameObject _gamePausedText;

    /// <summary>�^�C�g���{�^��</summary>
    [SerializeField] GameObject _titleButton;
    /// <summary>���g���C�{�^��</summary>
    [SerializeField] GameObject _reTryButton;
    /// <summary>�|�[�Y�{�^��</summary>
    [SerializeField] GameObject _pauseButton;
    /// <summary>�Q�[���o�ߎ��ԃe�L�X�g</summary>
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

    /// <summary>�Q�[���I�[�o�[���̏���</summary>
    void GameOver()
    {
        _gameOverText.SetActive(true);
        _reTryButton.SetActive(true);
        print("GameOver");
    }

    /// <summary>�Q�[���N���A�[���̏���</summary>
    void GameClear()
    {
        _gameClearText.SetActive(true);
        _titleButton.SetActive(true);
        print("GameClear");
    }

    /// <summary>�Q�[���|�[�Y���̏���</summary>
    void GamePaused()
    {
        _gamePausedText.SetActive(true);
        _titleButton.SetActive(true);
        Time.timeScale = 0;
        print("GamePaused");
    }

    /// <summary>�X�R�A���v�Z���郁�\�b�h</summary>
    /// <param name="time">�N���A�^�C��������</param>
    /// <param name="killCount">�G�̃L����������</param>
    /// <returns>�v�Z�������v�X�R�A��Ԃ�</returns>
    public float Score(float time, float killCount)
    {
        float score = 0;
        score += time * _scoreScale;
        score += killCount * _scoreScale;
        return score;
    }
}
