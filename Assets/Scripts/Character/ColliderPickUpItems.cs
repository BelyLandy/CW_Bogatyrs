using System;
using UnityEngine;

public class ColliderPickUpItems : MonoBehaviour
{
    public event Action<Collider, bool> OnPickUpItems;

    private void OnTriggerEnter(Collider other)
    {
        OnPickUpItems?.Invoke(other, true);

        Debug.Log("Entered " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        OnPickUpItems?.Invoke(other, false);

        Debug.Log("Exited " + other.name);
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     OnPickUpItems?.Invoke(other, true);
    // }
}
