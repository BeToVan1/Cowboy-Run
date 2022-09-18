using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
           
    }

    public GameObject GetPooledObject()
    {
        for(int j = 0; j < pooledObjects.Count; j++)
        {
            if(!pooledObjects[j].activeInHierarchy)
            {
                return pooledObjects[j];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
