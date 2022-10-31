using System.Collections.Generic;
using UnityEngine;

public class PullObjectGenerator : MonoBehaviour
{
    private List<GameObject> _pullObject = new List<GameObject>();

    public List<GameObject> CreatePullObject(GameObject[] spawnObjects, float objectCountInPull)
    {
        foreach (GameObject spawnObject in spawnObjects)
        {
            for (int i = 0; i < objectCountInPull; i++)
            {
                GameObject obj;
                obj = Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
                _pullObject.Add(obj);
                obj.SetActive(false);
            }
        }
        return _pullObject;
    }
}
