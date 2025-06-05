using System.Collections;
using UnityEngine;

public class EnemyBomberMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = .005f;
    private float _range;
    private int _damage;
    private bool _hasExploded = false;
    private Vector3 _targetPosition;

    public void Init(Transform target, int damage, float range)
    {
        _target = target;
        _range = range;
        _damage = damage;
        _hasExploded = false;

        // Crear una posición desplazada arriba del jugador
        _targetPosition = new Vector3(_target.position.x, _target.position.y + 1f, _target.position.z);

        StartCoroutine(MoveToPlayer());
    }

    private IEnumerator MoveToPlayer()
    {
        while (_target != null && Vector3.Distance(transform.position, _targetPosition) > _range)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        if (_hasExploded) return;
        _hasExploded = true;

        FindAnyObjectByType<PlayerScript>()?.TakeDamage(_damage);
        GetComponent<EnemyController>()?.Die();
    }
}