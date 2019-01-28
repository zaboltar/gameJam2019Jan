using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaseRate;
    public float health, thirst, hunger;

    PlayerManager player;
    public bool playerIsDead;

    public int collectedTreasure = 0;

    public void Start() {
        health = maxHealth;
        player = FindObjectOfType<PlayerManager>();

        if (PlayerPrefs.HasKey("commingFromBattle"))
        {
            PlayerPrefs.DeleteKey("commingFromBattle");
            RetrievePlayerPrefs();
        }
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
            Die();
        }

    }

    public void Die() {
        // Death mechanics and logic here
        // Valar Morghulis
        playerIsDead = true;

        //reload scene?
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
       
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
            hunger -= 10f;
            Destroy(other.gameObject);
        }

        if (other.tag == "collectableLiquid")
        {
            thirst -= 20f;
            Destroy(other.gameObject);
        }

        if (other.tag == "collectableHealth")
        {
            health += 5f;
            Destroy(other.gameObject);
        }

        if (other.tag == "iWillHurtYou")
        {
            health -= 20f;
            Destroy(other.gameObject);
        }

        if (other.tag == "goToBattleScene")
        {
            //Dont forget to save preferences before going into battle scene
            SavePlayerPrefs();

            //Dont forget to destroy the fighter. 
            Destroy(other.gameObject);
            
            //Change scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }

    }


    void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("originScene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.SetFloat("z", player.transform.position.z);
        PlayerPrefs.SetFloat("health", player.health);
        PlayerPrefs.SetFloat("thirst", player.thirst);
        PlayerPrefs.SetFloat("hunger", player.hunger);
        PlayerPrefs.SetInt("collectedTreasure", player.collectedTreasure);
    }

    void RetrievePlayerPrefs()
    {
        var x = PlayerPrefs.GetFloat("x");
        var y = PlayerPrefs.GetFloat("y");
        var z = PlayerPrefs.GetFloat("z");
        player.transform.position = new Vector3(x-2f, y, z);
        player.health = PlayerPrefs.GetFloat("health");
        player.thirst = PlayerPrefs.GetFloat("thirst");
        player.hunger = PlayerPrefs.GetFloat("hunger");
        player.collectedTreasure = PlayerPrefs.GetInt("collectedTreasure");
    }

}
