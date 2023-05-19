using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float _minPlayerSize = 0.1f;
    [SerializeField] private float _reducingPlayerValue = 0.03f;

    public float ReducingValue { get { return _reducingPlayerValue; } set { _reducingPlayerValue = value; } }

    private Coroutine _decreasePlayerRoutine;

    private void OnEnable()
    {
        AdditionalHealth.OnHealthCollected += IncreasePlayer;
    }

    private void OnDisable()
    {
        AdditionalHealth.OnHealthCollected -= IncreasePlayer;
    }

    private void Start()
    {
        // start coroutine that reduce our player all time
        _decreasePlayerRoutine = StartCoroutine(IDecreasePlayerRoutine());
    }

    private void IncreasePlayer(float additionalSize)
    {
        transform.localScale += new Vector3(0, additionalSize, 0);
    }

    private IEnumerator IDecreasePlayerRoutine()
    {
        while (transform.localScale.y >= _minPlayerSize)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale -= new Vector3(0, _reducingPlayerValue * Time.deltaTime, 0);
        }

        KillPlayer();
    }

    private void KillPlayer()
    {
        Destroy(gameObject);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
