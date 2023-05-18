using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TowerPlacementController;

public class BasicTroup : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MainBase.instance.transform.position, speed * Time.deltaTime);

        if (Vector3.Equals(transform.position, MainBase.instance.transform.position))
        {
            MainBase.instance.Damage();
            DestroyGameObject();
        }
    }

    public bool Damage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            DestroyGameObject();
            return true;
        }

        return false;
    }

    private void DestroyGameObject()
    {
        ObjectContainer.instance.RemoveTrope(this.gameObject);

        Destroy(this.gameObject);
    }
}
