using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    Vector3 oldpos;
    public int order;
    public static float combat_enemy_hp;
    public static float combat_enemy_maxhp;
    public float combat_enemy_attack;
    public GameObject damageText;
    private GameObject clone;

    // Use this for initialization
    void Start () {
        //We should initialize this character hp and stuff here (so it can be different every time we enter a fight. 
        combat_enemy_hp = 550;
        combat_enemy_maxhp = 550;
        combat_enemy_attack = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleFlowManager.currentTurn == order && BattleFlowManager.battleFieldsReady)
        {
            //Constrains enemy attacks
            BattleFlowManager.BlockBattlefield();

            //Set animator to attack
            //GetComponent<Animator>().SetTrigger("attack");

            //Set oldpos to get back after the attack
            oldpos = GetComponent<Transform>().position;

            //Set the target position
            Vector3 targetPosition = new Vector3(-18f, oldpos.y, oldpos.z);

            //In case of distance attack, instantiate arrow

            //Change position to put the player in front of enemy
            GetComponent<Transform>().position = targetPosition;

            //Change the turn
            BattleFlowManager.UpdateCurrentTurn();

            //Execute Damage
            BattleFlowManager.DoDamage("enemyAttacks", combat_enemy_attack);
            clone = (GameObject)Instantiate(damageText, new Vector3(-18f, oldpos.y+1, oldpos.z), Quaternion.Euler(Vector3.zero));
            var _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
            clone.transform.SetParent(_canvas.transform);

            StartCoroutine(returnFromAttack());
        }

    }

    IEnumerator returnFromAttack()
    {
        //Wait
        yield return new WaitForSeconds(0.5f);

        //Return player to old position
        GetComponent<Transform>().position = oldpos;

        //Let them attack you
        BattleFlowManager.ToggleBattefieldReady();

        //Destroy text clone
        Destroy(clone);

    }
}
