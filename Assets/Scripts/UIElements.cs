using System;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _loseScoreTxt;
    [SerializeField] private Text _bestScoreTxt;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private FactorsBonus _bonusFactors;

    private int _bestScore;
    private int _roundBestScore;

   public int Score { get; private set; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            _bestScore = PlayerPrefs.GetInt("BestScore");
        }

        Time.timeScale = 1;
        AddScore(15);
    }

    public void ShowLoseTexts()
    {
        _bestScoreTxt.text = "Best Score: " + _bestScore;
        _loseScoreTxt.text = "Score: " + _roundBestScore;
    }

    public int GetScoreValue()
    {
        return Score;
    }

    public void AddScore(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        Score += amount;
        _scoreTxt.text = Score.ToString();
        _bonusFactors.FactorButtonsVisible();
        _roundBestScore = Score;

        if (_bestScore < Score)
        {
            _bestScore = Score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
    }

    public void RemoveScore(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }

        Score -= amount;
        _scoreTxt.text = Score.ToString();
        _bonusFactors.FactorButtonsVisible();
    }

    public void ShowLosePanel()
    {
        _losePanel.SetActive(true);
        Invoke(nameof(TimeStopped), 2f);
    }

    private void TimeStopped()
    {
        Time.timeScale = 0;
    }
}