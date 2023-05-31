using System.Collections;
using UnityEngine;

public class Bullet : Poolable
{
    [SerializeField] private float _bulletSpeed = 9f;
    [SerializeField] private float _bulletLifeTimeInSSeconds = 3f;
    [SerializeField] private int _damage = 1;

    private void OnEnable()
    {
        StartCoroutine(BulletLifeManagerRoutine());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemyComponent)) 
        {
            enemyComponent.TakeDamage(_damage);

            ReleaseObject();
        }
    }

    private IEnumerator BulletLifeManagerRoutine()
    {
        yield return new WaitForSeconds(_bulletLifeTimeInSSeconds);

        ReleaseObject();
    }
}
