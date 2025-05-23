using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Behaviors/Ranged")]
public class RangedAttackSO : AttackSO
{
    public GameObject weapon;
    public GameObject projectilePrefab;
    public float delayShoot;
    public float bulletAmount;
    private float timer = 0;
    public override void ExecuteAttack(GameObject user, Transform target)
    {
        if (target != null)
        {
            if (timer > delayShoot)
            {
                Transform firePoint = user.transform.Find("FirePoint") ?? user.transform;
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                Vector3 direction = (target.position - firePoint.position).normalized;
                projectile.GetComponent<Rigidbody>().linearVelocity = direction * 10f; // ajustar velocidad
                timer = 0;
            }
            else { timer += Time.deltaTime; }
        }
    }

   
}