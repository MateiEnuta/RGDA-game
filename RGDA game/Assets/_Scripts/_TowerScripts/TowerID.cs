using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerID : MonoBehaviour
{
    public Action<GameObject> onTargetFound;
    public Action onTargetDestroyed;
    public Action onTowerFire;
}
