using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMaker : MonoBehaviour {

    PlayerManager playerStats;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoDamage();
        }

   
    }

    public void DoDamage()
    {
        playerStats.health -= 20;
    }
}
