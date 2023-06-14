using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemGridCreator : MonoBehaviour
{
    public Vector2 gridSize;
    public float padding;
    public GridCellController cellPrefab;
    public List<GridCellController> cells;

    private void OnEnable()
    {
        EventManager.SetCellGem += SetCellGem;
    }

    private void OnDisable()
    {
        EventManager.SetCellGem -= SetCellGem;
    }

    [Button]
    public void CreateGrid()
    {
        ClearCreatedCells();

        var gemHolder = EventManager.GetGemHolder();
        for (int i = 0; i < gridSize.y; i++)
        {
            for (int j = 0; j < gridSize.x; j++)
            {
                var cell = Instantiate(cellPrefab.gameObject, transform).GetComponent<GridCellController>();
                var gridBound = cell.GetBound()+padding;
                var xStart = ((gridSize.x * gridBound) - (gridBound)) / 2;
                var yStart = ((gridSize.y * gridBound) - (gridBound)) / 2;
                cell.transform.localPosition = new Vector3((-xStart+(gridBound*j)), 0, -yStart+(gridBound*i));
                cells.Add(cell);
                SetCellGem(cell);
            }
        }
    }

    public void SetCellGem(GridCellController cell)
    {
        var gemHolder = EventManager.GetGemHolder();
        cell.cellGem = gemHolder.allGems[Random.Range(0,gemHolder.allGems.Count)];
        cell.GrowGem();

    }

    void ClearCreatedCells()
    {
        foreach (var cell in cells)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(cell.gameObject);
            }
            else
            {
                Destroy(cell.gameObject);
            } 
        }
        cells.Clear();
    }
    
}
