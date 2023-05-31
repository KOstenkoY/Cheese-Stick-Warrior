using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Poolable _poolablePrefab;

    [SerializeField] private int _defaultCapacity = 15;
    [SerializeField] private int _maxPoolSize = 30;

    public IObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            true, _defaultCapacity, _maxPoolSize);
    }

    private GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(_poolablePrefab.gameObject);
        obj.GetComponent<Poolable>().Pool = Pool;

        return obj;
    }

    private void OnTakeFromPool(GameObject obj) => obj.SetActive(true);

    private void OnReturnedToPool(GameObject obj) => obj.SetActive(false);

    private void OnDestroyPoolObject(GameObject obj) => Destroy(obj);
}
