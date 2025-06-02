using TMPro;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    private TextMeshProUGUI textRound;
    private void Start()
    {
        textRound = GetComponent<TextMeshProUGUI>();
    }
    public void ActualizarTextoEnemies(int round)
    {
        textRound.text = "Round: " + round;
    }
}