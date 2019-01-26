using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextController : MonoBehaviour {

    public Text text; 
	// Use this for initialization
	void Start () {
        //Destroy(gameObject, 1.0f);


    }
	
	// Update is called once per frame
	void Update () {
        text.text = BattleFlowManager.currentDamage.ToString();
    }
}
