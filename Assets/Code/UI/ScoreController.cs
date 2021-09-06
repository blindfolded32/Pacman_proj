using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour, IScore
{
    private Text _scoreText;
    private float _pillScore = 100.0f;
    private float _duration = 10.0f;

    public float multi { get; set; }
    public float score { get; private set; }
    public event IScore.Collected OnCollect;

    private void Start()
    {
        _scoreText = GetComponent<Text>();
        score = 0.0f;
        multi = 1.0f;
        Debug.Log(_scoreText.text);
    }

    public void ScoreIncrease()
    {
        score += (_pillScore*multi);
        _scoreText.text =$"Score: {score}";
    }

    public void ChangeMulti(float value)
    {
        StartCoroutine(Timer(value, _duration));
    }

    IEnumerator Timer(float multi, float value)
    {
        multi = value;
        yield return new WaitForSeconds(value);
        float origin = multi;
    }
}
