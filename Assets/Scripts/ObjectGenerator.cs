using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;
    [SerializeField] private int poolSize = 6;
    [SerializeField] private float generationDistance = 40f;
    [SerializeField] private float generationHeight = 2f;

    private ObjectPool<GameObject> objectPool;
    private int objectCount;
    private int indexPrefab = 0;
    private Camera mainCamera;
    private List<GameObject> activeObjects = new List<GameObject>();

    private void Start()
    {
        mainCamera = Camera.main;
        objectPool = new ObjectPool<GameObject>
            (() => InstantiatePrefab(), null, obj => obj.SetActive(false));
        objectCount = 0;
    }

    private void Update()
    {
        for (int i = 0; i < activeObjects.Count; i++)
        {
            GameObject obj = activeObjects[i];
            if (obj.transform.position.x < mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x)
            {
                if (obj.activeInHierarchy)
                {
                    obj.SetActive(false);
                    objectPool.Release(obj);
                    objectCount--;
                }
                activeObjects.RemoveAt(i);
                i--;
            }
        }

        if (objectCount < poolSize)
        {
            GenerateObjects();
        }
    }

    private void GenerateObjects()
    {
        GameObject obj = objectPool.Get();
        float x = mainCamera.transform.position.x + Random.Range(5f, generationDistance);
        float y = Random.Range(-generationHeight, generationHeight);
        Vector3 spawnPosition = new Vector3(x, y, 0f);
        bool isTooClose = false;

        obj.transform.position = spawnPosition;
        obj.SetActive(true);
        objectCount++;
        activeObjects.Add(obj);
    }

    private GameObject InstantiatePrefab()
    {
        GameObject prefab = objectPrefabs[indexPrefab];
        indexPrefab++;
        return Instantiate(prefab);
    }

    public void ReleaseObject(GameObject obj)
    {
        if (obj.activeInHierarchy)
        {
            obj.SetActive(false);
            objectPool.Release(obj);
            objectCount--;

            GenerateObjects();
        }
    }
}
