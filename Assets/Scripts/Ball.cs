using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    private UIElements _scoreChanger;
    private SpriteRenderer _renderer;
    private bool _isHaveImageComponent;
    private int _ballAmount = 2;

    private void OnEnable()
    {
        if (!_isHaveImageComponent)
        {
            _renderer = GetComponent<SpriteRenderer>();
            _scoreChanger = FindObjectOfType<UIElements>();
            _isHaveImageComponent = true;
        }
    }

    public SpriteRenderer GetRenderer()
    {
        return _renderer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (_renderer.sprite != ball.GetRenderer().sprite)
                return;

            _scoreChanger.AddScore(_ballAmount);
            gameObject.SetActive(false);
        }
    }
}