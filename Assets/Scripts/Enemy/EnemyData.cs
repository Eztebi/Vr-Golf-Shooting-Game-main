using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
    public GameObject prefab;
    public GameObject projectilePrefab;
    public AttackSO attack;
}
