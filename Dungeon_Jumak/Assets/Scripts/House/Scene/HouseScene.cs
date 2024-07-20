using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScene : BaseScene
{
    [SerializeField]
    private GameObject Inventory;

    private void Start()
    {
        Inventory.gameObject.SetActive(false);
    }

    protected override void Init()
    {
        SceneType = Define.Scene.House;
    }

    public override void Clear()
    {
        Debug.Log("House Scene changed!");
    }

    public void ChangeScene(string sceneName)
    {
        if (Enum.TryParse(sceneName, out Define.Scene scene))
        {
            GameManager.Scene.LoadScene(scene);
        }
    }
}
