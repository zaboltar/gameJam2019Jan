using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    public float health, thirst, hunger;


    public bool playerIsDead;

    public int collectedTreasure = 0;

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

        if (health <= 0)
        {
            Die();
        }




        if (health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }

    public void Die() {
        // Death mechanics and logic here
        // Valar Morghulis
        playerIsDead = true;
        //reload scene?
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectableTreasure")
        {
            collectedTreasure++;
            Destroy(other.gameObject);

        }

        if (other.tag == "collectableFood")
        {
            hunger += 10f;
            Destroy(other.gameObject);
        }

        if (other.tag == "collectableLiquid")
        {
            thirst += 20f;
            Destroy(other.gameObject);
        }

        if (other.tag == "collectableHealth")
        {
            health += 5f;
            Destroy(other.gameObject);
        }
    }

}
