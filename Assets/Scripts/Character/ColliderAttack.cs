using System;
using UnityEngine;

public class ColliderAttack : MonoBehaviour
{
    public event Action<Collider, bool> OnAttack;

    private void OnTriggerEnter(Collider other)
    {
        OnAttack?.Invoke(other, true);

        Debug.Log("Entered " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        OnAttack?.Invoke(other, false);

        Debug.Log("Exited " + other.name);
    }
}