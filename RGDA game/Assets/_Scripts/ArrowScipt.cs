using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScipt : MonoBehaviour
{
    [SerializeField] private float ArrowSpeed, Damange;

    private GameObject Target, Sender;

    public void SetTarget(GameObject target, GameObject sender)
    {
        Target = target;
        Sender = sender;
    }

    private void Update()
    {
        if (Target == null) return;

        if (Vector3.Equals(Target, this.gameObject))
        {
            if (Target.TryGetComponent<IDamageable>(out var component))
            {
                if (component.Damage(Damange))
                {
                    if (Sender.TryGetComponent<ArrowDmangeSystem>(out var system))
                    {
                        system.OnTargetDestroyed();
                    }
                }
            }

            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.MoveTowards(transform.position, Target.transform.position, ArrowSpeed * Time.deltaTime));
        transform.LookAt(Target.transform);
    }
}
