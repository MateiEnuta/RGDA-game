using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TowerPlacementController;

public class HailProjectile : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float duration;
    [SerializeField] private float damangePerSecond;
    [SerializeField] protected float targetSerchInterval = 0.1f;


    private void Start()
    {
        StartCoroutine(startLifeTimeTimer());

        StartCoroutine(StartSerchLoop());
    }

    private IEnumerator startLifeTimeTimer()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }

    private IEnumerator StartSerchLoop()
    {
        SerchForTarget();

        yield return new WaitForSeconds(targetSerchInterval);

        StartCoroutine(StartSerchLoop());
    }

    private void SerchForTarget()
    {
        List<GameObject> Targets = ObjectContainer.instance.ReturnTropeContainers();
        List<GameObject> AvailableTargets = new List<GameObject>();

        foreach (GameObject target in Targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= maxDistance)
            {
                AvailableTargets.Add(target);
            }
        }

        foreach (GameObject target in AvailableTargets)
        {
            if (target.TryGetComponent<IDamageable>(out var component))
            {
                component.Damage(damangePerSecond * targetSerchInterval);
            }
        }
    }
}
