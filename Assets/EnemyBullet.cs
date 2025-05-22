using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.CompareTag("Player")) {
    //        PlayerScript player = collision.collider.GetComponent<PlayerScript>();
    //        player.TakeDamage(damage);
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}