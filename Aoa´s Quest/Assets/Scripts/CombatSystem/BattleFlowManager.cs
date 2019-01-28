using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFlowManager : MonoBehaviour
{

    public static int currentTurn = 0;
    public static int fightersLength;
    public static bool battleFieldsReady = false;
    public static float currentDamage = 0f;
    //public List<string> EnemyList;
    public PlayerAttack playerFighter;
    public EnemyAttack enemy;
    private static int whereHeCameFrom;
    private bool endFight = false;

    // Use this for initialization
    void Start()
    {
        whereHeCameFrom = PlayerPrefs.GetInt("originScene");
        fightersLength = 1;
        battleFieldsReady = true;
        //This should be a method when we want more than 1 enemy
        //EnemyList.Add(EnemyAttack.enemy_name);
    }

    // Update is called once per frame
    void Update()
    {

        //Check if all enemies or all players are death
        if (EnemyAttack.isDeath || PlayerAttack.isDeath)
        {
            endFight = true;
        }

        if (endFight)
        {
            ExecuteOrder666();
        }

    }

    //Update the current Turn so we know whos next
    public static void UpdateCurrentTurn()
    {
        if (currentTurn < fightersLength)
        {
            currentTurn++;
        }
        else
        {
            currentTurn = 0;
        }
    }

    //Let them attack you
    public static void ToggleBattefieldReady()
    {
        battleFieldsReady = true;
    }

    public static void DoDamage(string type, float attack_power)
    {
        currentDamage = attack_power;
        if (type == "enemyAttacks")
        {
            PlayerAttack.combat_player_hp -= currentDamage;
            Debug.Log("PlayerHP:");
            Debug.Log(PlayerAttack.combat_player_hp);

        }
        else
        {
            Debug.Log("EnemyHP:");
            Debug.Log(EnemyAttack.combat_enemy_hp);
            EnemyAttack.combat_enemy_hp -= currentDamage;
        }

    }

    public static void ExecuteOrder666()
    {
        battleFieldsReady = false;
        //here we need to go back to the scene (if the player wons)
        if (EnemyAttack.isDeath)
        {
            PlayerPrefs.SetInt("commingFromBattle", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene(whereHeCameFrom);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
    }

    //or nai
    public static void BlockBattlefield()
    {
        battleFieldsReady = false;
    }
}
