using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemyTargeting : TowerSystem
{
    [SerializeField] private float maxDistance;
    [SerializeField] protected float targetSerchInterval = 0.1f;

    private GameObject currentTarget = null;

    private void Start()
    {
        StartCoroutine(StartSerchLoop());
    }

    private void Update()
    {
        if (currentTarget == null) return;
        Debug.DrawLine(transform.position, currentTarget.transform.position);
    }

    private IEnumerator StartSerchLoop()
    {
        SerchForTarget();

        yield return new WaitForSeconds(targetSerchInterval);

        StartCoroutine(StartSerchLoop());
    }

    private void SerchForTarget()
    {
        List<GameObject> targets = ObjectContainer.instance.ReturnTropeContainers();

        float minDistance = Mathf.Infinity;
        GameObject closestObject = null;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestObject = target;
            }
        }

        if (minDistance <= maxDistance && closestObject != currentTarget)
        {
            currentTarget = closestObject;
            tower.onTargetFound?.Invoke(closestObject);
        }
    }
}
