using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(Image))]
public class FadeAnimator : MonoBehaviour
{
    public event UnityAction FadeComplite;

    [SerializeField] private float _duration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void FadeInOut()
    {
        gameObject.SetActive(true);
        Sequence _fadeSequence = DOTween.Sequence();
        _fadeSequence.Append(_image.DOFade(1, _duration))
            .AppendCallback(() => FadeComplite?.Invoke())
            .Append(_image.DOFade(0, _duration))
            .AppendCallback(() => gameObject.SetActive(false));
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        Sequence _fadeSequence = DOTween.Sequence();
        _fadeSequence.Append(_image.DOFade(1, _duration))
            .AppendCallback(() => FadeComplite?.Invoke());
    }
}
