using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nighttime : MonoBehaviour {
    public Button shop;
    public Button nextDay;
    public Button menu;
    public Button settings;

    public Canvas Shop;
    public Canvas Settings;
    public Canvas MainMenu;

    // Use this for initialization
    void Start ()
    {
        shop.onClick.AddListener(onClickShop);
        nextDay.onClick.AddListener(onClicknextDay);
        menu.onClick.AddListener(onClickMenu);
        settings.onClick.AddListener(onClickSettings);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void onClicknextDay()
    {
        
    }

    void onClickShop()
    {
        Shop.enabled = true;
    }

    void onClickMenu()
    {
        MainMenu.enabled = true;
    }

    void onClickSettings()
    {
        Settings.enabled = true;
    }
}
