using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider hpBar;
    public Slider hungerBar;
    public Slider thirstBar;
    public PlayerManager playerManager;
    public Text collectedTreasures;

    // Use this for initialization
    void Start () {
        playerManager = GetComponent<PlayerManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        hpBar.maxValue = playerManager.maxHealth;
        hpBar.value = playerManager.health;

        hungerBar.maxValue = playerManager.maxHunger;
        hungerBar.value = playerManager.hunger;

        thirstBar.maxValue = playerManager.maxThirst;
        thirstBar.value = playerManager.thirst;

        collectedTreasures.text = "$ = " + playerManager.collectedTreasure;
	} // EL EJEMPLO USA DONT DESTROY ON LOAD PARA EL CANVAS 
}
