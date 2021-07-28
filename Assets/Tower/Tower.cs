using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false; }
        if (bank.getCurrentGold() >= cost)
        {
            Instantiate(tower.gameObject, position, new Quaternion());
            bank.withdrawGold(cost);
            return true;
        }
        else { return false; }
    }
}