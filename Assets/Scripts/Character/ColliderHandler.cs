using UnityEngine;

public class ColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!CollisionManager.Instance.IsObjectRegistered(other.gameObject))
        {
            CollisionManager.Instance.RegisterObject(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CollisionManager.Instance.IsObjectRegistered(other.gameObject))
        {
            CollisionManager.Instance.UnregisterObject(other.gameObject);
        }
    }
}