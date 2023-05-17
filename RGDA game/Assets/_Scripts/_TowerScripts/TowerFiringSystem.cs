using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TowerFiringSystem : TowerSystem
{
    [SerializeField] private float damage;
    [SerializeField] private float firingSpeed;

    private GameObject CurrentTarget = null;
    private float LastTime;

    private void StartFiring(GameObject target)
    {
        CurrentTarget = target;
    }

    private void Update()
    {
        if (CurrentTarget == null) return;

        if (Time.time > LastTime + firingSpeed)
        {
            LastTime = Time.time;

            if (CurrentTarget.TryGetComponent<IDamageable>(out var component))
            {
                if (component.Damage(damage))
                {
                    CurrentTarget = null;
                    tower.onTargetDestroyed?.Invoke();
                }
            }
        }
    }


    private void OnEnable()
    {
        tower.onTargetFound += StartFiring;
    }

    private void OnDisable()
    {
        tower.onTargetFound -= StartFiring;
    }
}
