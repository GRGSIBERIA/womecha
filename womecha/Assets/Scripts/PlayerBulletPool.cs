using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerBulletPool : MonoBehaviour
{
    ObjectPool<GameObject> pool;

    [SerializeField]
    GameObject target;

    public GameObject PoolingObject
    {
        get { return target; }
        set { target = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        pool = new ObjectPool<GameObject>(OnCreatePool, OnGetPool, OnReleasePool, OnDestroyPool);
    }

    GameObject OnCreatePool()
    {
        return Instantiate(target);
    }

    void OnDestroyPool(GameObject obj)
    {
        Destroy(obj);
    }

    void OnGetPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnReleasePool(GameObject obj)
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject InstantiatePooling(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        target = prefab;
        GameObject obj = pool.Get();
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        return obj;
    }

    void ReleasePooling(GameObject obj)
    {
        pool.Release(obj);
    }
}
