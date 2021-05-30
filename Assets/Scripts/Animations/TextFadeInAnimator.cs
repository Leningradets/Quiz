using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextFadeInAnimator : MonoBehaviour
{
    [SerializeField] private float _duration;
    private TMP_Text _tMP_Text;

    private void Start()
    {
        _tMP_Text = GetComponent<TMP_Text>();
        _tMP_Text.color = new Color(_tMP_Text.material.color.r, _tMP_Text.material.color.g, _tMP_Text.material.color.b, 0);
        _tMP_Text.DOFade(1, _duration);
    }
}
