using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducingZone : MonoBehaviour
{
    // additional reducing coefficient
    [SerializeField] private float _reducingPlayerCoefficient = 0.1f;

    private float _reducingPlayerValue;
    private float _newReducingPlayerValue;

    public float NewReducingPlayerCoefficient { set => _newReducingPlayerValue = value; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerHealthControllerComponent))
        {
            _reducingPlayerValue = playerHealthControllerComponent.ReducingValue;

            playerHealthControllerComponent.ReducingValue = _newReducingPlayerValue + _reducingPlayerCoefficient;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealthController>(out PlayerHealthController playerHealthControllerComponent))
        {
            playerHealthControllerComponent.ReducingValue = _reducingPlayerValue;
        }
    }
}
