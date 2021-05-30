using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceAnimator : MonoBehaviour
{
    [SerializeField] private float _duration;

    private bool _isSceneStart;

    public bool IsSceneStart { get => _isSceneStart; set => _isSceneStart = value; }

    private void Start()
    {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, _duration).SetEase(Ease.OutBounce);
    }
}
