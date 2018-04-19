using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance; //Make sure this is only one instance of build manager.

    private void Awake()
    {
        instance = this;
    }

    public GameObject turrentToBuild; //CHANGE THIS GameObject to change turret

    public bool SellButtonVisible = false;

    public GameObject turretToSell;

    public GameObject GetTurrenToBuild()
    {
        return turrentToBuild;
    }

    public GameObject GetTurreToSell()
    {
        return turretToSell;
    }

}
