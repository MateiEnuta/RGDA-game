using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSystem : MonoBehaviour
{
    protected TowerID tower;

    private void Awake()
    {
        tower = transform.root.GetComponent<TowerID>();
    }
}
