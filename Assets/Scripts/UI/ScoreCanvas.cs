using TMPro;
using UnityEngine;
using Zenject;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _scoreValue;
    [SerializeField]
    private EndGameCanvas _endGameCanvas;

    private ScoreCounter _scoreCounter;
    private int _score;

    [Inject]
    private void Construct(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }


    private void Start()
    {
        _scoreCounter.ScoreChanged += ScoreChange;
    }

    private void ScoreChange(int score)
    {
        _scoreValue.text = score.ToString();
        _score = score;
    }

    private void OnDisable()
    {
        _endGameCanvas.SetScore(_score);
        _scoreCounter.ScoreChanged -= ScoreChange;
    }
}
