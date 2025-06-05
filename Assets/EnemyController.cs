using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class EnemyController : MonoBehaviour
{
    [SerializeField] public EnemyData _enemyData;
    [SerializeField] private Transform _target;

    private int _currentHealth;
    private float _speed;
    private bool _isDead = false;

    private void Start()
    {
        if (_enemyData != null)
        {
            _currentHealth = _enemyData.health;
            _speed = _enemyData.speed;

            _target = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
        else
        {
            Debug.LogWarning("EnemyData no asignado en " + gameObject.name);
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_enemyData.attack != null)
        {
            _enemyData.attack.ExecuteAttack(this.gameObject, _target);
        }
    }

    public void RecieveDamage(int damage)
    {
        if (_enemyData != null)
        {
            _currentHealth -= damage;
            Debug.Log(_currentHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        if (_isDead || _enemyData == null) return;
        _isDead = true;

        StartCoroutine(DieAnimation());
    }

    private IEnumerator DieAnimation()
    {
        float duration = 1.5f;
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.up * 2f;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        FindAnyObjectByType<RoundManager>()?.EnemigoEliminado();
        Destroy(gameObject);
    }
}