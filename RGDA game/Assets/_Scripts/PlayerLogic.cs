using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private bool nextturn;
    [SerializeField] private float timertimemax;
    public static PlayerLogic instance;

    private int wavenumber;
    private bool early;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public bool IsItEarly()
    {
        return early;
    }

    public int WhastsTheWaveNumber()
    {
        return wavenumber;
    }

    private void Update()
    {
        if (nextturn)
        {
            nextturn = false;
            wavenumber += 1;
            early = true;
            float timertime = timertimemax;
            countdown(timertime);
        }
    }

    private void countdown(float countdown)
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            early = false;
        }
    }
}
