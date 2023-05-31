using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private float _reducingPlayerValueAfterShooting = 0.05f;

    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private ObjectPool _bulletPool;

    private PlayerHealthController _playerHealthController;

    private void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
    }

    private void OnEnable()
    {
        InputSystem.OnFire += Shoot;
    }

    private void OnDisable()
    {
        InputSystem.OnFire -= Shoot;
    }

    public void Shoot()
    {
        // after shoot reduce player size
        _playerHealthController.ReducePlayer(_reducingPlayerValueAfterShooting);

        GameObject bullet = SpawnBullet();
    }

    private GameObject SpawnBullet()
    {
        GameObject bullet = _bulletPool.Pool.Get();
        bullet.transform.SetPositionAndRotation(_bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
        bullet.transform.SetParent(_bulletPool.transform);

        return bullet;
    }
}
