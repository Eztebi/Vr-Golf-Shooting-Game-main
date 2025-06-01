using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool hasEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hasEnemy = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hasEnemy = false;
        }
    }
}