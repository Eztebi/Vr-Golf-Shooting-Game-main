using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
    public GameObject prefab;
    public AttackSO attack;
    public EnemyType enemyType;

    public EnemyData(string enemyName, int health, float speed, GameObject prefab, AttackSO attack, EnemyType enemyType)
    {
        this.enemyName = enemyName;
        this.health = health;
        this.speed = speed;
        this.prefab = prefab;
        this.attack = attack;
        this.enemyType = enemyType;
    }
}

