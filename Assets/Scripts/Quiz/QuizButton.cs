using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class QuizButton : MonoBehaviour
{
    public event UnityAction Click;
    public event UnityAction CorrectAnimationEnded;

    [SerializeField] private Image _iconImage;
    [SerializeField] private StarsFX _starsFX;

    private bool _isCorrect;
    private bool _playAnimation;
    private ContentAnimator _contentAnimator;
    private Image _image;
    private Button _button;

    public bool IsCorrect { get => _isCorrect; set => _isCorrect = value; }
    public bool PlayAnimation { get => _playAnimation; set => _playAnimation = value; }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _contentAnimator = GetComponentInChildren<ContentAnimator>();


        Click += OnClick;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }

    private void Start()
    {
        if (!_playAnimation)
        {
            GetComponent<BounceAnimator>().enabled = false;
        }
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    public void SetSprite(Sprite sprite)
    {
        _iconImage.sprite = sprite;
    }

    public string GetName()
    {
        return _iconImage.sprite.name;
    }

    public void OnClick()
    {
        AnimationType contentAnimationType;

        if (_isCorrect)
        {
            contentAnimationType = AnimationType.Correct;
            _contentAnimator.AnimationEnded += OnCorrectAnimationEnded;
            Instantiate(_starsFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        else
        {
            contentAnimationType = AnimationType.Wrong;
        }

        _contentAnimator.StartAnimation(contentAnimationType);
    }

    public void OnCorrectAnimationEnded()
    {
        CorrectAnimationEnded?.Invoke();
        _contentAnimator.AnimationEnded -= OnCorrectAnimationEnded;
    }
}
