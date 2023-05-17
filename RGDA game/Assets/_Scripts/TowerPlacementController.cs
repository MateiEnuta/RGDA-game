using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    [SerializeField] private Tower[] towers;

    public static TowerPlacementController instance { get; private set; }

    [System.Serializable]
    public class Tower
    {
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
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out hit, 100))
        {
            Vector3 positionInWorld = hit.point;
        }
    }

    public void ChangeTower()
    {

    }

    public void PlaceTower()
    {

    }
}
