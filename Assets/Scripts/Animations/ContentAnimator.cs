using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ContentAnimator : MonoBehaviour
{
    public event UnityAction AnimationEnded;

    [SerializeField] private float _duration;
    [SerializeField] private float _correctAnsweAnimationStrenght;
    [SerializeField] private float _wrongAnsweAnimationStrenght;

    public void StartAnimation(AnimationType animationType)
    {
        if(animationType == AnimationType.Correct)
        {
            StartCorrectAnswerAnimation();
        }
        else if(animationType == AnimationType.Wrong)
        {
            StartWrongAnswerAnimation();
        }
    }

    private void StartCorrectAnswerAnimation()
    {
        transform.DOPunchScale(Vector3.one * _correctAnsweAnimationStrenght, _duration).OnComplete(() => AnimationEnded?.Invoke());
    }
    
    private void StartWrongAnswerAnimation()
    {
        transform.DOPunchRotation(Vector3.forward * _wrongAnsweAnimationStrenght, _duration).OnComplete(() => AnimationEnded?.Invoke());
    }
}

public enum AnimationType
{
    Correct,
    Wrong
}
