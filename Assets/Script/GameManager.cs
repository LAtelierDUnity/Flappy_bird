using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("LunchGame")]
    public bool firstTouch = false;
    public bool isDead = false;

    [Header("PipeList")]
    [SerializeField]
    private List<PipeMove> _allPipes;

    [Header("Ref")]
    [SerializeField]
    private PipeManager _pipeManager;
    [SerializeField]
    private Rigidbody2D _playerRb;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private FloatingEffect _floatingEffect;
    [SerializeField]
    private GameObject _uiStartGame;
    [SerializeField]
    private LoopGround _ground;


    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _socreText;

    private int score;


    private void Awake()
    {
        instance = this;
        StopAll();
    }

    private void StopAll()
    {
        _pipeManager.enabled = false;
        _playerRb.gravityScale = 0;
        _uiStartGame.SetActive(true);
        _floatingEffect.enabled = true;
    }


    public void AllActivate()
    {
        _pipeManager.enabled = true;
        _playerRb.gravityScale = 1;
        _uiStartGame.SetActive(false);
        _floatingEffect.enabled = false;

    }

    public void AddScore()
    {
        score++;
        _socreText.text = score.ToString();
    }

    public void AddPipe(PipeMove pipe)
    {
        _allPipes.Add(pipe);
    }

    public void RemovePipe(PipeMove pipe)
    {
        _allPipes.Remove(pipe);
    }

    public void PlayerDead()
    {
        isDead = true;
        _ground.enabled = false;
        _animator.enabled = false;
    }
}
