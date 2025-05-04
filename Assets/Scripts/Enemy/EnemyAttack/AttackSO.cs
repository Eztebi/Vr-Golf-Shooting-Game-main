using UnityEngine;

public abstract class AttackSO : ScriptableObject
{
    public abstract void ExecuteAttack(GameObject user, Transform target);
}