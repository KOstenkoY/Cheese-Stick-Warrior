using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private PlayerHealthController _playerHealthController;

    private void Awake()
    {
        _playerHealthController = GetComponent<PlayerHealthController>();
    }

    public void Shoot()
    {
        // after shoot reduce player size
        _playerHealthController.ReducePlayer();    

        //logic for shooting
    }
}
