using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private ColliderAttack _attack;
    private List<GameObject> baseAttackObjects = new();
    
    private void Awake()
    {
        _attack = GetComponentInChildren<ColliderAttack>();
    }
    
    private void OnEnable()
    {
        _attack.OnAttack += HandleAttack;
    }

    private void HandleAttack(Collider other, bool isEntering)
    {
        // Если объект входит в триггер и он еще не добавлен в список
        if (isEntering)
        {
            if (!baseAttackObjects.Contains(other.gameObject))
            {
                baseAttackObjects.Add(other.gameObject);
            }
        }
        else
        {
            baseAttackObjects.Remove(other.gameObject);
        }

        Debug.Log("Current objects in trigger: " + baseAttackObjects.Count);
    }
    
    private void PerformAttack()
    {
        if (baseAttackObjects.Count == 0)
        {
            Debug.Log("No valid Base Attack Objects!");
            return;
        }
        
        // foreach (var target in baseAttackObjects)
        // {
        //     HandleAttackOnObject(target);
        // }
        //
        // baseAttackObjects = baseAttackObjects
        //     .Except(validTargets)
        //     .ToList();
    }
}
