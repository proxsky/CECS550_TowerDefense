﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    
    public Color hoverColor; //Color when mouse is over block

    private Color stockColor; //Original material color
    private Renderer r; //Render component of the block
    private GameObject turret; //Turret on block
    
    void Start()
    {
        r = GetComponent<Renderer>();
        stockColor = r.material.color;
    }

    /// <summary>
    /// Build turret if there isn't one on the block.
    /// </summary>
    private void OnMouseDown()
    {
        if(turret != null)       
            return;

        GameObject buildTurret = BuildManager.instance.GetTurrenToBuild();
        turret = Instantiate(buildTurret, transform.position, transform.rotation);                
    }

    /// <summary>
    /// Change color of block when mouse is move.
    /// </summary>
    private void OnMouseEnter()
    {
        //If there is already a turret, hover color is red.
        if (turret == null)
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