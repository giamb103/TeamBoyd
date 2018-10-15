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
    public Canvas Night;

    // Use this for initialization
    void Start ()
    {
        MainMenu.enabled = false;
        Settings.enabled = false;
        Shop.enabled = false;
        Night.enabled = true;

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
        MainMenu.enabled = false;
        Settings.enabled = false;
        Shop.enabled = true;
        Night.enabled = false;
    }

    void onClickMenu()
    {
        MainMenu.enabled = true;
        Settings.enabled = false;
        Shop.enabled = false;
        Night.enabled = false;
    }

    void onClickSettings()
    {
        MainMenu.enabled = false;
        Settings.enabled = true;
        Shop.enabled = false;
        Night.enabled = false;
    }
}
