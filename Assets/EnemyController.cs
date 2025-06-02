using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public EnemyData _enemyData;
    [SerializeField] Transform _target;

    private int _currentHealth;
    private float _speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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


    // Update is called once per frame
    void Update()
    {
        if (_target !=null)
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

    private void Die()
    {
        if(_enemyData != null)
        {
           if(_currentHealth <= 0)
            {
               StartCoroutine(DieAnimation());
            }
        }
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

        FindAnyObjectByType<RoundManager>().EnemigoEliminado();
        Destroy(gameObject);
    }
    public void RecieveDamage(int damage)
    {
        Die();
        if (_enemyData != null)
        {
            _currentHealth -= damage;
            Debug.Log(_currentHealth);
        }
        Die();
    }
}
