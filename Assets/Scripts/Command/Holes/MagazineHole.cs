using EasyTextEffects;
using System.Collections;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MagazineHole : MonoBehaviour
{
    [SerializeField]private SpawnMagazines spawneer;


    [SerializeField] private GameObject canvas;
    private TextMeshProUGUI text;
    private TextEffect effect;
    private Coroutine effectCoroutine;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        effect = GetComponentInChildren<TextEffect>();
        canvas.SetActive(false);
    }
    private IEnumerator ShowEffectCoroutine(int score)
    {
        canvas.SetActive(true);
        ShowText(score);
        yield return new WaitForSeconds(1f);
        canvas.SetActive(false);
    }
    private void ShowText(int score)
    {
        text.text ="+" + score.ToString();
        effect.StartManualEffects();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (spawneer == null)
            {
                Debug.Log("No espawneoMagazines");
                return;
            }

            else
            {
                ICommand commandSpawnMag = new ISpawnMagazines(spawneer, spawneer.magPrefabs);
                CommandInvoker.ExecuteCommand(commandSpawnMag);
            }
            Ball ball = other.GetComponent<Ball>();
            if (ball != null)
            {
                if (ball.Score == 0)
                {
                    ICommand commandScore = new IScoreMultiplier(ball, 50);
                    CommandInvoker.ExecuteCommand(commandScore);
                    if (effectCoroutine != null)
                        StopCoroutine(effectCoroutine);

                    effectCoroutine = StartCoroutine(ShowEffectCoroutine(50));
                }
                else
                {
                    ICommand commandScore = new IScoreMultiplier(ball, ball.Score);
                    CommandInvoker.ExecuteCommand(commandScore);
                    if (effectCoroutine != null)
                        StopCoroutine(effectCoroutine);

                    effectCoroutine = StartCoroutine(ShowEffectCoroutine(ball.Score));
                }
           
                ball.DeactivateHit();
            }
            
        }
    }

}
        

