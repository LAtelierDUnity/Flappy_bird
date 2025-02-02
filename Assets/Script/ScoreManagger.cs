using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagger : MonoBehaviour
{
    public static ScoreManagger instance;
    [Header("Player Score Checkpoint")]
    [SerializeField]
    private List<int> _scorecheckpoint;


    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI _socreText;
    [SerializeField]
    private GameObject _deadUi;
    [SerializeField]
    private List<GameObject> _medalUI;
    [SerializeField]
    private TextMeshProUGUI _scoreUIDead;
    [SerializeField]
    private TextMeshProUGUI _bestScoreUIDead;
    [SerializeField]
    private GameObject _newBestScoreUI;

    private int score;
    private int _bestscore;

    private void Awake()
    {
        instance = this;
        LoadBestScore();
        _newBestScoreUI.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        _socreText.text = score.ToString();
    }

    public void CheckScorePlayer()
    {


        if(score < _scorecheckpoint[0])
        {
            Debug.Log("Pas de médaille");
        }
        else if (score < _scorecheckpoint[1])
        {
            _medalUI[0].SetActive(true);
        }
        else if (score < _scorecheckpoint[2])
        {
            _medalUI[1].SetActive(true);
        }
        else if(score < _scorecheckpoint[3])
        {
            _medalUI[2].SetActive(true);
        }
        else
        {
            _medalUI[3].SetActive(true);
        }

        _deadUi.SetActive(true);
        _socreText.gameObject.SetActive(false);

        SaveBestScore();
        SetDeadText();
    }

    public void ResteMedalUI()
    {
        foreach (GameObject medal in _medalUI)
        {
            medal.SetActive(false);
        }

    }

    private void SetDeadText()
    {
        _scoreUIDead.text = score.ToString();
        _bestScoreUIDead.text = _bestscore.ToString();

    }

    private void SaveBestScore()
    {
        if(score > _bestscore)
        {
            _bestscore = score;
            PlayerPrefs.SetInt("BestScore", _bestscore);
            PlayerPrefs.Save();
            _newBestScoreUI.SetActive(true);
            Debug.Log("Best score est égale a :" + _bestscore);

        }
    }

    private void LoadBestScore()
    {
        _bestscore = PlayerPrefs.GetInt("BestScore", _bestscore);
        Debug.Log("Best score est égale a :" + _bestscore);
    }
}
