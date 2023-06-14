using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float _timer;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<GridCellController>())
        {
            var cell = other.GetComponentInParent<GridCellController>();
            if (cell.currentGem.transform.localScale.x > .25f)
            {
                EventManager.StackGem(cell.currentGem);
                
            }
            else
            {
                Debug.Log("Can't Collect");
            }
        }
        else if (other.GetComponentInParent<SellAreaController>())
        {
            _timer += Time.deltaTime;
            if (_timer>.1f)
            {
                EventManager.SellGem();
                _timer = 0;
            }
        }
    }
}