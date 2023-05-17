using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public static ObjectContainer instance { get; private set; }

    private List<GameObject> TroupesContainer, TowersContainer;

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

        TroupesContainer = new List<GameObject>();
        TowersContainer = new List<GameObject>();

        DontDestroyOnLoad(this.gameObject);
    }

    public void AddTrope(GameObject obj) { TroupesContainer.Add(obj); }
    public void RemoveTrope(GameObject obj) { TroupesContainer.Remove(obj); }

    public void AddTower(GameObject obj) { TowersContainer.Add(obj); }
    public void RemoveTower(GameObject obj) { TowersContainer.Remove(obj); }

    public List<GameObject> ReturnTropeContainers() {  return TroupesContainer; }
    public List<GameObject> ReturnTowerContainers() { return TowersContainer; }
}
