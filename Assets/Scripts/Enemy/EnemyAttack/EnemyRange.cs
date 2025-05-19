using UnityEngine;

[CreateAssetMenu(menuName = "Attack Behaviors/Ranged")]
public class RangedAttackSO : AttackSO
{
    public GameObject weapon;
    public GameObject projectilePrefab;
    public float delayShoot;
    public float bulletAmount;

    public override void ExecuteAttack(GameObject user, Transform target)
    {
        Transform firePoint = user.transform.Find("FirePoint") ?? user.transform;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        Vector3 direction = (target.position - firePoint.position).normalized;
        projectile.GetComponent<Rigidbody>().linearVelocity = direction * 10f; // ajustar velocidad
        Debug.Log($"{user.name} dispara un proyectil a {target.name} (ranged)");
    }

   
}