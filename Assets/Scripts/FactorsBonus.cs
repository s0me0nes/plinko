using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FactorsBonus : MonoBehaviour
{
    [SerializeField] private Button _x2Button, _x3Button, _x5Button;
    [SerializeField] private UIElements _elements;
    [SerializeField] private Text _bonusTimerTxt;

    private Coroutine _coroutine;

    private int _x2Price = 10;
    private int _x3Price = 50;
    private int _x5Price = 100;
    private int _bonusTime = 8;
    private int _currentBonusTime;
    private bool _isBonusHasActivated;

    public bool _isX2HasActive { get; private set; }
    public bool _isX3HasActive { get; private set; }
    public bool _isX5HasActive { get; private set; }


    public void FactorButtonsVisible()
    {
        if (!_isBonusHasActivated)
        {
            _x2Button.interactable = _x2Price <= _elements.Score;
            _x3Button.interactable = _x3Price <= _elements.Score;
            _x5Button.interactable = _x5Price <= _elements.Score;
        }
    }

    public void BuyFactor(int price)
    {
        if (_elements.GetScoreValue() >= price)
        {
            _elements.RemoveScore(price);
            _coroutine = StartCoroutine(BonusTimer());

            if (price == _x2Price)
            {
                _isX2HasActive = true;
            }
            else if (price == _x3Price)
            {
                _isX3HasActive = true;
            }
            else
            {
                _isX5HasActive = true;
            }

            _isBonusHasActivated = true;
        }
    }

    private void BonusHasLeft()
    {
        _isX2HasActive = false;
        _isX3HasActive = false;
        _isX5HasActive = false;
        _isBonusHasActivated = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator BonusTimer()
    {
        _bonusTimerTxt.gameObject.SetActive(true);
        _currentBonusTime = _bonusTime;

        var timer = new WaitForSeconds(1f);

        while (true)
        {
            if (_currentBonusTime >= 0)
            {
                _bonusTimerTxt.text = _currentBonusTime.ToString();
                _currentBonusTime--;
            }
            else
            {
                _bonusTimerTxt.gameObject.SetActive(false);
                BonusHasLeft();
            }

            yield return timer;
        }
    }
}
