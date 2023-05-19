using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] protected Transform _reducingZone;

    [SerializeField] protected float _speed = 0.5f;

    [SerializeField] protected Vector2 _startPosition;
    [SerializeField] protected Vector2 _finishPosition;


    protected Vector2 _randomPlatformPosition;

    private float _trackPercent;
    protected int _direction;

    private void Awake()
    {
        // random position between Start position and Finish position
        _randomPlatformPosition = new Vector2(
            Random.Range(_startPosition.x, _finishPosition.x), 
            Random.Range(_startPosition.y, _finishPosition.y));

        // set random direction
        int randomDirection = Random.Range(0, 2);
        _direction = randomDirection == 0 ? -1 : 1;
    }

    private void FixedUpdate()
    {
        _trackPercent += _direction * _speed * Time.deltaTime;

        float newPositionX = (_finishPosition.x - _startPosition.x) * _trackPercent + _startPosition.x;
        float newPositionY = (_finishPosition.y - _startPosition.y) * _trackPercent + _startPosition.y;

        transform.position = new Vector2(newPositionX, newPositionY);

        if((_direction == 1 && _trackPercent > 0.9f) || (_direction == -1 && _trackPercent < 0.1f))
        {
            _direction *= -1;
        }
    }
}
