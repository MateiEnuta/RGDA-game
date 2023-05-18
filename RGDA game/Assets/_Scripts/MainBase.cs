using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBase : MonoBehaviour
{
    public float Health = 100;

    public static MainBase instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void Damage()
    {
        Health -= 10;
        if (Health < 0)
        {
            RestartGame();
        }
    }

    public void Update()
    {
        float spawntimermatraguna = 30f;
        if (spawntimermatraguna < 0)
        {
            spawntimermatraguna -= Time.deltaTime;
        }
        else
        {
            PlayerLogic.instance.Matragunaadd();
        }
        float spawntimerfiarelor = 60f;
        if (spawntimerfiarelor < 0)
        {
            spawntimerfiarelor -= Time.deltaTime;
        }
        else
        {
            PlayerLogic.instance.Fiareadd();
        }

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}