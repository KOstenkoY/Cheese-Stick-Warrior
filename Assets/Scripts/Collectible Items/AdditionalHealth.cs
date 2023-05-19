using UnityEngine;

// PlayerHealthController subscribes on this script
public class AdditionalHealth : MonoBehaviour, ICollectible
{
    [SerializeField] private float additionalPlayerSize = 0.3f;

    public static event System.Action<float> OnHealthCollected;

    public void Collect()
    {
        OnHealthCollected?.Invoke(additionalPlayerSize);

        Destroy(gameObject);
    }
}
