using System.Collections;
using UnityEngine;

public class Bullet : Poolable
{
    [SerializeField] private float _bulletSpeed = 9f;
    [SerializeField] private float _bulletLifeTimeInSSeconds = 3f;

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
        ReleaseObject();
    }

    private IEnumerator BulletLifeManagerRoutine()
    {
        yield return new WaitForSeconds(_bulletLifeTimeInSSeconds);

        ReleaseObject();
    }
}
