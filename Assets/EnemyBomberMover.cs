using System.Collections;
using UnityEngine;

public class EnemyBomberMover : MonoBehaviour
{
    [SerializeField]private Transform _target;
    [SerializeField] private Vector3[] _points;
    private float _speed = 3f;
    private float _range;
    private float _damage;

    public void Init(Vector3[] points, Transform target, float damage, float range)
    {
        _points = points;
        _target = target;
        _range = range;
        _damage = damage;

        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        foreach (var point in _points)
        {
            while (Vector3.Distance(transform.position, point) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);
                yield return null;
            }
        }

        // Ahora ir al jugador
        while (Vector3.Distance(transform.position, _target.position) > _range)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {

        FindAnyObjectByType<RoundManager>()?.EnemigoEliminado();
        Destroy(gameObject);
    }
}