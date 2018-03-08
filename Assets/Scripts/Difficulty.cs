using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Difficulty : MonoBehaviour {

    public static int difficulty = 0;
    public TMP_Dropdown dropDown;

	// Use this for initialization
	void Start () {

        difficulty = dropDown.value;

    }
	
	public void SelectionChanged()
    {
     
        difficulty = dropDown.value;
    }


}
