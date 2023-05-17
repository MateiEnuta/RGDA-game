using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicTroup : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    [SerializeField] private float speed;

    private Vector3 TargetLocation;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetLocation, speed * Time.deltaTime);


        // Temporar.
        if (transform.position == TargetLocation) DestroyGameObject();
    }

    public void SetTargetLocation(Vector3 TargetLocation)
    {
        this.TargetLocation = TargetLocation;
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
