using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] private List<Ball> _balls;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Transform _parentObject;
    [SerializeField] private Sprite[] _colors;
    [SerializeField] private UIElements _scoreChanger;

    private int _ballPrice = 1;
    private bool _isMoneyLeft;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (_scoreChanger.GetScoreValue() >= _ballPrice)
            {
                _scoreChanger.RemoveScore(_ballPrice);
                TryGetBall();
            }
            else
            {
                Invoke(nameof(TryShowLosePanel), 8f);
            }
        }
    }

    private void TryShowLosePanel()
    {
        if (_scoreChanger.GetScoreValue() >= _ballPrice)
            return;

        _scoreChanger.ShowLosePanel();
        _scoreChanger.ShowLoseTexts();
    }

    private void TryGetBall()
    {
        foreach (var ball in _balls)
        {
            if (!ball.gameObject.activeSelf)
            {
                ball.gameObject.SetActive(true);
                ball.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

                SpriteSetter(ball);

                return;
            }
        }

        Ball ballPrefab = Instantiate(_ballPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
        _balls.Add(ballPrefab);
        SpriteSetter(ballPrefab);
        //ballPrefab.transform.parent = _parentObject;
    }

    private void SpriteSetter(Ball ball)
    {
        ball.GetRenderer().sprite = _colors[Random.Range(0, _colors.Length)];
    }
}