using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TowerFiringSystem : TowerSystem
{
    private float damage;
    [SerializeField] private float firingSpeed;

    private GameObject CurrentTarget = null;
    private float LastTime;

    private void StartFiring(GameObject target)
    {
        CurrentTarget = target;
    }

    private void Update()
    {
        damage = PlayerLogic.instance.Matragunavalue();

        if (CurrentTarget == null) return;

        if (Time.time > LastTime + firingSpeed)
        {
            LastTime = Time.time;

            tower.onTowerFire?.Invoke(CurrentTarget);

            if (CurrentTarget.TryGetComponent<IDamageable>(out var component))
            {
                if (component.Damage(damage))
                {
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
