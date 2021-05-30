using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteArray
{
    [SerializeField] private Sprite[] _array;

    public List<Sprite> GetRandomSprites(int count)
    {
        var indexes = GetRandomIndexes(count);

        var sprites = new List<Sprite>();

        foreach (var index in indexes)
        {
            sprites.Add(_array[index]);
        }

        return sprites;
    }

    private List<int> GetRandomIndexes(int count)
    {
        var indexes = new List<int>();

        if(count > _array.Length)
        {
            throw new System.IndexOutOfRangeException();
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Range(0, _array.Length);

            if (!indexes.Contains(index))
            {
                indexes.Add(index);
            }
            else
            {
                i--;
            }
        }

        return indexes;
    }
}

public class QuizGenerator : MonoBehaviour
{
    [SerializeField] private QuizViewer _viewer;
    [SerializeField] private SpriteArray[] _spriteArrays;
    [SerializeField] private Color[] _buttonsColors;
    [SerializeField] private QuizButton _quizButtonTemplate;

    private Transform _transform;
    private List<QuizButton> _buttons;
    private int _correctButton;
    private List<string> _guessed = new List<string>();

    public int CorrectButton => _correctButton;

    private void Awake()
    {
        _transform = transform;
    }

    public List<QuizButton> Generate(int level, bool playAnimation)
    {
        _buttons = new List<QuizButton>();

        var sprites = _spriteArrays[Random.Range(0, _spriteArrays.Length)].GetRandomSprites(level * 3);

        foreach (var sprite in sprites)
        {
            var button = Instantiate(_quizButtonTemplate, _transform);
            button.SetSprite(sprite);
            button.SetColor(_buttonsColors[Random.Range(0, _buttonsColors.Length)]);
            button.PlayAnimation = playAnimation;
            _buttons.Add(button);
        }

        QuessButton();

        return _buttons;
    }

    private void QuessButton()
    {
        bool ungessed = true;

        while (ungessed)
        {
            _correctButton = Random.Range(0, _buttons.Count);
            if (!_guessed.Contains(_buttons[_correctButton].GetName()))
            {
                _buttons[_correctButton].IsCorrect = true;
                _viewer.SetName(_buttons[_correctButton].GetName());
                _guessed.Add(_buttons[_correctButton].GetName());
                ungessed = false;
            }
        }
    }
}
