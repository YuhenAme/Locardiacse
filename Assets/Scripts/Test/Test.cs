using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //GameSystem.BattleSystem.GetEmeny();
        GameSystem.ScriptSystem.PlayScript("dialogues", "dialogues");
        Debug.Log(GameSystem.ScriptSystem.GetRole() + GameSystem.ScriptSystem.GetRoleDetail());
        

    }
}
