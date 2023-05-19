using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float _reducingCoefficient = 0.03f;
    [SerializeField] private float _minPlayerSize = 0.1f;

    public float ReducingCoefficient { get { return _reducingCoefficient; } set { _reducingCoefficient = value; } }

    private Coroutine _decreasePlayerRoutine;

    private void Start()
    {
        // start coroutine that reduce our player all time
        _decreasePlayerRoutine = StartCoroutine(IDecreasePlayerRoutine());
    }

    private IEnumerator IDecreasePlayerRoutine()
    {
        while (transform.localScale.y >= _minPlayerSize)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale -= new Vector3(0, _reducingCoefficient * Time.deltaTime, 0);
        }

        KillPlayer();
    }

    private void KillPlayer()
    {
        Destroy(gameObject);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
