using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private FadeAnimator _fadeAnimator;

    public void OnFadeComplite()
    {
        _fadeAnimator.FadeComplite -= OnFadeComplite;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartScene()
    {
        _fadeAnimator.FadeComplite += OnFadeComplite;
        _fadeAnimator.FadeIn();
    }
}
