using System.Collections;
//Enable to use lists
using System.Collections.Generic;
using UnityEngine;



public class ObjectPooler : MonoBehaviour {
    public GameObject pooledObject;
    public int pooledAmount;
    List<GameObject> pooledObjects;

	void Start () {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }
	}

    //get an object that is not active to put it in front active
    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; ++i)
        {
            //isnt active in the scene
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }

        }

        // if thereis not an inactive onject in the list create one (OBJ) and return it 
        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);

        return obj;
     }

    }
