using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    [SerializeField] private Slider sliderScore;

    void Start()
    {
        sliderScore = GetComponent<Slider>();

        RoundManager.Instance.ScoreGoal.AddListener((nuevoMax) =>
        {
            sliderScore.maxValue = nuevoMax;
        });

        RoundManager.Instance.Score.AddListener((nuevoScore) =>
        {
            sliderScore.value = Mathf.Clamp(nuevoScore, 0, sliderScore.maxValue);
        });
    }

    public void ActualizaScore(int score)
    {
        sliderScore.value = Mathf.Clamp(score, 0, sliderScore.maxValue);
    }
}