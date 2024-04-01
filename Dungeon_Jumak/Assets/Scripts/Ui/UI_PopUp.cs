using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_PopUp : UI_Base
{
    //Virtual Method (가상 함수) : 파생 클래스에서 필요에 따라 재정의 할 수 있음
    public virtual void Init()
    {
        GameManager.UI.SetCanvas(gameObject, true);
    }
    public virtual void ClosePopupUI()
    {
        GameManager.UI.ClosePopupUI(this);
    }
}