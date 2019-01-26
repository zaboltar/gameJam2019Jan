using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    private float health, thirst, hunger;

    public bool playerIsDead;

    public void Start() {
        health = maxHealth;
    }

    public void Update() {
        // thirst and hunger increases

       

        if (!playerIsDead)
        {
            hunger += hungerIncreaseRate * Time.deltaTime;
            thirst += thirstIncreaseRate * Time.deltaTime;
        }


        if (thirst >= maxThirst)
        {
            Die();
        }

        if (hunger >= maxHunger)
        {
            Die();
        }

    }

    public void Die() {
        // Death mechanics and logic here
        // Valar Morghulis
        playerIsDead = true;
    }

}
