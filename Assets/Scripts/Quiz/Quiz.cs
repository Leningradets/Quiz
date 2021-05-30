using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuizGenerator))]
public class Quiz : MonoBehaviour
{
    [SerializeField] private FadeAnimator _fadeAnimator;
    [SerializeField] private int _maxQuizLevel;
    [SerializeField] private RestartButton _restartButton;

    private int _quizLevel = 1;
    private QuizGenerator _generator;
    private List<QuizButton> _buttons;

    private void Start()
    {
        _generator = GetComponent<QuizGenerator>();

        Generate(true);
    }

    private void Generate(bool playAnimation)
    {
        _buttons = _generator.Generate(_quizLevel, playAnimation);
        _buttons[_generator.CorrectButton].CorrectAnimationEnded += OnCorrectAnimationEnded;
    }

    public void OnCorrectAnimationEnded()
    {
        if (_quizLevel < _maxQuizLevel)
        {
            _fadeAnimator.FadeComplite += OnFadeInOutComplite;
            _fadeAnimator.FadeInOut();
        }
        else
        {
            _fadeAnimator.FadeComplite += OnFadeInComplite;
            _fadeAnimator.FadeIn();
        }

        _buttons[_generator.CorrectButton].CorrectAnimationEnded -= OnCorrectAnimationEnded;
    }

    public void OnFadeInOutComplite()
    {
        foreach (var button in _buttons)
        {
            Destroy(button.gameObject);
        }

        _quizLevel++;

        Generate(false);

        _fadeAnimator.FadeComplite -= OnFadeInOutComplite;
    }

    public void OnFadeInComplite()
    {
        _fadeAnimator.FadeComplite -= OnFadeInComplite;
        _restartButton.gameObject.SetActive(true);
    }
}
