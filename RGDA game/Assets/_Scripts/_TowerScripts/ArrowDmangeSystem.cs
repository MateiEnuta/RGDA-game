using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDmangeSystem : TowerSystem
{
    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private Vector3 FireOffset;

    public void Throw(GameObject Target)
    {
        GameObject arrow = Instantiate(ArrowPrefab, transform.position + FireOffset, Quaternion.identity);
        if (arrow.TryGetComponent<ArrowScipt>(out var component))
        {
            component.SetTarget(Target, this.gameObject);
        }
    }

    public void OnTargetDestroyed()
    {
        tower.onTargetDestroyed?.Invoke();
    }

    private void OnEnable()
    {
        tower.onTowerFire += Throw;
    }

    private void OnDisable()
    {
        tower.onTowerFire -= Throw;
    }
}
