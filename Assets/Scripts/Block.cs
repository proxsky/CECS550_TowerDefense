﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Color hoverColor; //Color when mouse is over block

    private Color stockColor; //Original material color
    private Renderer r; //Render component of the block

    private GameObject turret; //Turret on block


   

    public GameObject turretUI;

    //testing
    public int turretCost = 25;

    void Start()
    {
        r = GetComponent<Renderer>();
        stockColor = r.material.color;
    }

    private void Update()
    {
        switch(BuildManager.instance.GetTurrenToBuild().tag)
        {
            case "Basic":
                turretCost = 25;
                break;

            case "AOE":
                turretCost = 50;
                break;

            default:
                break;

        }
    }

    /// <summary>
    /// Build turret if there isn't one on the block.
    /// </summary>
    private void OnMouseDown()
    {
        if (turret != null && Input.GetKey(KeyCode.LeftShift)) {
            Destroy(turret);
            Tracker.money += turretCost;
            return;
        }

        if(turret != null) {

            //test
            BuildManager.instance.turretToSell = turret;
           // turretUI.transform.position = turret.transform.position;
            //BuildManager.instance.SellButtonVisible = true;

            if(BuildManager.instance.SellButtonVisible)
            {
                turretUI.transform.position = new Vector3(-100, -100, -100);
                BuildManager.instance.SellButtonVisible = false;
            }
            else
            {
                BuildManager.instance.turretToSell = turret;
                turretUI.transform.position = turret.transform.position;
                BuildManager.instance.SellButtonVisible = true;
            }

            return;
        }


        
        if (Time.timeScale != 0 && turretCost <= Tracker.money && BuildManager.instance.SellButtonVisible==false)
        {
            Tracker.money -= turretCost;

            GameObject buildTurret = BuildManager.instance.GetTurrenToBuild();
            turret = Instantiate(buildTurret, transform.position, transform.rotation);
        }



        //GameObject buildTurret = BuildManager.instance.GetTurrenToBuild();
        //turret = Instantiate(buildTurret, transform.position, transform.rotation);                
    }

    /// <summary>
    /// Change color of block when mouse is move.
    /// </summary>
    private void OnMouseEnter()
    {
        //If there is already a turret, hover color is red.
        if (turret == null && turretCost <= Tracker.money)
            GetComponent<Renderer>().material.color = hoverColor;
        else
            GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// Change block color back.
    /// </summary>
    private void OnMouseExit()
    {
        r.material.color = stockColor;
    }

}
