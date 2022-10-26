using TMPro;
using UnityEngine;

public class EndGameCanvas : MonoBehaviour
{
    const string KEY_RECORD = "record";

    [SerializeField]
    private TMP_Text _recordValue;
    [SerializeField]
    private TMP_Text _scoreValue;

    private int _score;

    public void SetScore(int score)
    {
        _score = score;
    }

    private void OnEnable()
    {
        SetScore();
        SetRecord();
    }

    private void SetRecord()
    {
        int record = SaveLoaderRecord.Load(KEY_RECORD);
        if (record >= _score)
        {
            _recordValue.text = record.ToString();
        }
        else
        {
            _recordValue.text = _score.ToString();
            SaveLoaderRecord.Save(KEY_RECORD, _score);
        }
    }

    private void SetScore()
    {
        _scoreValue.text = _score.ToString();
    }
}
