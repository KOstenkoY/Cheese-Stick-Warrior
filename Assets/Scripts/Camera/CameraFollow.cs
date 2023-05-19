using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // our player
    [SerializeField] private Transform _target;

    // must be quals how in the main player
    [SerializeField] private float _constantSpeed = 3f;
    // it's additional speed, that add to constant speed when the player speeds up
    [SerializeField] private float _accelerationValue = 1.5f;

    [SerializeField] private Transform _centerLimitPosition;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();

        transform.position = new Vector3(_target.position.x, 0, transform.position.z);

        float width = _camera.pixelWidth / 2;
    }

    private void Update()
    {
        if(_target != null)
        {
            if(_target.position.x < _centerLimitPosition.position.x)
            {
                transform.Translate(_constantSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                Vector3 targetPosition = new Vector3(_target.position.x, transform.position.y, -10);

                Vector3 pos = Vector3.Lerp(this.transform.position, targetPosition, _accelerationValue * Time.deltaTime);

                transform.position = pos;
            }
        }
    }
}
