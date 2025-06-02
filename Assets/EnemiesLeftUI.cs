using TMPro;
using UnityEngine;

public class EnemiesLeftUI : MonoBehaviour
{ 
    private TextMeshProUGUI textEnemies;
private void Start()
{
    textEnemies = GetComponent<TextMeshProUGUI>();
}
public void ActualizarTextoEnemies(int enemies)
{
    textEnemies.text = "Enemies: " + enemies;
}
}