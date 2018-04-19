using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour {

    public Button button;

    private void Update()
    {

        if(BuildManager.instance.GetTurreToSell()!=null)
        {
            switch (BuildManager.instance.GetTurreToSell().tag)
            {
                case "Basic":
                    button.GetComponentInChildren<Text>().text = "Sell: $13";
                    break;

                case "AOE":
                    button.GetComponentInChildren<Text>().text = "Sell: $25";
                    break;

                default:
                    button.GetComponentInChildren<Text>().text = "Sell: $10";
                    break;

            }
        }
       
       
    }

    public void SellClick()
    {
        GameObject sellTurret = BuildManager.instance.GetTurreToSell();

        switch(BuildManager.instance.GetTurreToSell().tag)
        {
            case "Basic":
                Tracker.money += 13;
                break;

            case "AOE":
                Tracker.money += 25;
                break;

            default:
                Tracker.money += 10;
                break;

        }


        Destroy(sellTurret);

        BuildManager.instance.SellButtonVisible = false;

        gameObject.transform.position = new Vector3(-100, -100, -100);

    }
       

}
