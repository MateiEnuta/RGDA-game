using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    [SerializeField] private Tower[] towers;

    private int currentTowerIndex = 0;

    private GameObject CurrentTroupe;

    public static TowerPlacementController instance { get; private set; }

    [System.Serializable]
    public class Tower
    {
        public bool EmptyHand;
        public GameObject towerPrefab, placingTowerPrefab;
        public float towerGroundOffset;
    }

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

    private void Update()
    {
        if (towers[currentTowerIndex].towerPrefab == null) return;

        RaycastHit hit;
        Vector3 positionInWorld = Vector3.zero;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100000))
        {
            positionInWorld = hit.point;
        }

        CurrentTroupe.transform.position = positionInWorld;
    }

    public void ChangeTower()
    {
        if (currentTowerIndex > towers.Length)
        {
            if (CurrentTroupe != null) CurrentTroupe.SetActive(false);
            CurrentTroupe = null;
            currentTowerIndex = 0;
            return;
        }

        currentTowerIndex++;

        if (towers[currentTowerIndex].EmptyHand)
        {
            CurrentTroupe = null;
            if (CurrentTroupe != null) CurrentTroupe.SetActive(false);
            return;
        }

        if (CurrentTroupe != null) CurrentTroupe.SetActive(false);
        CurrentTroupe = Instantiate(towers[currentTowerIndex].placingTowerPrefab);
    }

    public void PlaceTower()
    {
        if (towers[currentTowerIndex].towerPrefab == null) return;

        RaycastHit hit;
        Vector3 positionInWorld = Vector3.zero;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100000))
        {
            positionInWorld = hit.point;
        }

        GameObject tower = Instantiate(towers[currentTowerIndex].towerPrefab, positionInWorld, Quaternion.identity);
        ObjectContainer.instance.AddTower(tower);
    }
}
