using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//背包UI
public class BackpackUI : BaseUI {
    private Button btn_exit;
    private void Start()
    {
        btn_exit = GameSystem.MenuSystem.FindChildByName(gameObject, "ExitButton").GetComponent<Button>();
        btn_exit.onClick.AddListener(Exit);
    }
    private void Exit()
    { 
        gameObject.GetComponent<BackpackUI>().CloseUI();
    }
    
}
