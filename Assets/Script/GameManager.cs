using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("LunchGame")]
    public bool firstTouch;

    [Header("Ref")]
    [SerializeField]
    private PipeManager _pipeManager;
    [SerializeField]
    private Rigidbody2D _playerRb;
    [SerializeField]
    private FloatingEffect _floatingEffect;
    [SerializeField]
    private GameObject _uiStartGame;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _socreText;

    private int score;


    private void Awake()
    {
        instance = this;
        StopAll();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
