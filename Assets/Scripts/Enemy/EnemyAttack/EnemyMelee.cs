using UnityEngine;

[CreateAssetMenu(menuName = "Attack Behaviors/Melee")]
public class MeleeAttackSO : AttackSO
{
    public float damage = 10f;
    public float range = 1f;    
    public override void ExecuteAttack(GameObject user, Transform target)
    {
    }
}