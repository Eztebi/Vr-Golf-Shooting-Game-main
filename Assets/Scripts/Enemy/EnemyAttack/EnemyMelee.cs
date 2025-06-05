using UnityEngine;

[CreateAssetMenu(menuName = "Attack Behaviors/Melee")]
public class MeleeAttackSO : AttackSO
{
    public int damage = 10;
    public float range = 1f;

    public override void ExecuteAttack(GameObject user, Transform target)
    {
        EnemyBomberMover mover = user.GetComponent<EnemyBomberMover>();
        if (mover == null)
        {
            mover = user.AddComponent<EnemyBomberMover>();
        }

        mover.Init(target, damage, range);
    }
}