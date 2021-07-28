using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] bool isTaken;

    public bool GetIsTaken()
    {
        return isTaken;
    }
    private void OnMouseDown()
    {
        if (!isTaken)
        {
            bool isPlaced = tower.CreateTower(tower, this.transform.position);
            isTaken = isPlaced;
        }
    }
}
