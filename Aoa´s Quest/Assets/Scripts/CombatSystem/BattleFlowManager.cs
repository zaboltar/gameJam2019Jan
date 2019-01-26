using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFlowManager : MonoBehaviour
{

    public static int currentTurn = 0;
    public static int fightersLength;
    public static bool battleFieldsReady = false;
    public static float currentDamage = 0f;

    public PlayerAttack playerFighter;
    public EnemyAttack enemy;


    // Use this for initialization
    void Start()
    {
        fightersLength = 1;
        battleFieldsReady = true;
    }

    // Update is called once per frame
    void Update()
    {

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

    //or nai
    public static void BlockBattlefield()
    {
        battleFieldsReady = false;
    }
}
