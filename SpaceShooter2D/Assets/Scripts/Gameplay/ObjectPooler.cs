using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private bool _autoExpand;
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private List<Pool> _pools;
    [SerializeField] private Dictionary<string, List<GameObject>> _poolDictionary;

    private void Start()
    {
        _poolDictionary = new Dictionary<string, List<GameObject>>();
        foreach (Pool pool in _pools)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i < pool.Size; i++)
                objectPool.Add(AddNewObject(pool.Prefab));

            _poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string name, string tag, Vector3 position, Quaternion rotation)
    {
        GameObject obj = FindFreeObject(name);
        obj.tag = tag;
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        if(obj.TryGetComponent(out Plane plane))
            plane.IsDestroyed = false;

        return obj;
    }

    private GameObject AddNewObject(GameObject prefab)
    {
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        return newObj;
    }

    private GameObject FindFreeObject(string tag)
    {
        foreach (GameObject obj in _poolDictionary[tag])
            if (!obj.activeSelf)
                return obj;

        if (!_autoExpand) return null;

        Pool pool = _pools.Where(t => t.Tag == tag).First();
        GameObject newObj = AddNewObject(pool.Prefab);
        _poolDictionary[tag].Add(newObj);
        return newObj;
    }
}
