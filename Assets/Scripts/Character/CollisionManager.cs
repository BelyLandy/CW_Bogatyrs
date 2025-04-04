using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager Instance { get; private set; }

    private HashSet<GameObject> detectedObjects = new HashSet<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterObject(GameObject obj)
    {
        if (!detectedObjects.Contains(obj))
        {
            detectedObjects.Add(obj);
            Debug.Log($"Объект {obj.name} добавлен в список. Сейчас внутри {detectedObjects.Count} объектов");
        }
    }

    public void UnregisterObject(GameObject obj)
    {
        if (detectedObjects.Contains(obj))
        {
            detectedObjects.Remove(obj);
            Debug.Log($"Объект {obj.name} удален из списка. Сейчас внутри {detectedObjects.Count} объектов");
        }
    }

    public bool IsObjectRegistered(GameObject obj)
    {
        return detectedObjects.Contains(obj);
    }
}