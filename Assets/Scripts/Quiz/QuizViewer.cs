using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class QuizViewer : MonoBehaviour
{
    private TMP_Text _tMP_Text;

    private void Awake()
    {
        _tMP_Text = GetComponent<TMP_Text>();
    }

    public void SetName(string name)
    {
        _tMP_Text.text = $"Find {name}";
    }
}
