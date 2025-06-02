using UnityEngine;

[CreateAssetMenu(menuName = "Attack Behaviors/Melee")]
public class MeleeAttackSO : AttackSO
{
    public float damage = 10f;
    public float range = 1f;
    public override void ExecuteAttack(GameObject user, Transform target)
    {
        EnemyBomberMover mover = user.GetComponent<EnemyBomberMover>();
        if (mover == null)
        {
            mover = user.AddComponent<EnemyBomberMover>();
        }

        Vector3 p1 = user.transform.position + user.transform.right * 2f;
        Vector3 p2 = user.transform.position + user.transform.forward * 2f;

        mover.Init(new Vector3[] { p1, p2 }, target, damage, range);
    }
}