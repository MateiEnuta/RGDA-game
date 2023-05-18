using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    public static MainBase instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }


}
