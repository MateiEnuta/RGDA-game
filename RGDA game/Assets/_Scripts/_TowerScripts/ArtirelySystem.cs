using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtirelySystem : TowerSystem
{
    [SerializeField] private GameObject hailProjectile;
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

            tower.onTowerFire?.Invoke(CurrentTarget);

            Instantiate(hailProjectile, CurrentTarget.transform.position, Quaternion.identity);
            CurrentTarget = null;
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
