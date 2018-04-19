using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTurret : MonoBehaviour {

    public GameObject basicTurret;
    public GameObject aoeTurret;
    public Button basicButton;
    public Button aoeButton;

    public Color original;
    public Color changeColor;


    void Start () {

        original = basicButton.GetComponent<Image>().color;

        basicButton.GetComponent<Image>().color = changeColor;
    }


    public void BasicClick()
    {
        BuildManager.instance.turrentToBuild = basicTurret;       

        basicButton.GetComponent<Image>().color = changeColor;
        aoeButton.GetComponent<Image>().color = original;
    }

    public void AOEClick()
    {
        BuildManager.instance.turrentToBuild = aoeTurret;

        basicButton.GetComponent<Image>().color = original;
        aoeButton.GetComponent<Image>().color = changeColor;
    }
}
