using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MovablePlatform
{
    private void Start()
    {
        // set the value to X, because the plaform is mooving vertically
        _startPosition.x = transform.position.x;
        _finishPosition.x = transform.position.x;

        // spawn latform in random position between Start position and Finish position
        transform.position = _randomPlatformPosition;

        // character reduction factor depends on platform speed
        _reducingZone.GetComponent<ReducingZone>().NewReducingPlayerCoefficient = _speed;

    }
}
