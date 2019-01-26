using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    Vector3 oldpos;
    public static float combat_player_hp;
    public static float combat_player_maxhp;

    public static float combat_player_attack;
    public GameObject damageText;
    private GameObject clone;



    // Use this for initialization
    void Start () {
        //We should initialize this character hp and stuff here (so it can be different every time we enter a fight. 
        combat_player_hp = 100;
        combat_player_maxhp = 100;
        combat_player_attack = 50;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space") && BattleFlowManager.currentTurn == 0 && BattleFlowManager.battleFieldsReady)
        {
            //Constrains enemy attacks
            BattleFlowManager.BlockBattlefield();

            //Set animator to attack
            //GetComponent<Animator>().SetTrigger("attack");

            //Set oldpos to get back after the attack
            oldpos = GetComponent<Transform>().position;

            //Set the target position
            Vector3 targetPosition = new Vector3(-15.0f, oldpos.y, oldpos.z);

            //In case of distance attack, instantiate arrow

            //Change position to put the player in front of enemy
            GetComponent<Transform>().position = targetPosition;

            //Change the turn (so you can only attack once)
            BattleFlowManager.UpdateCurrentTurn();

            //Execute Damage
            BattleFlowManager.DoDamage("playerAttacks", combat_player_attack);
            clone = (GameObject)Instantiate(damageText, new Vector3(-13f, oldpos.y + 1, oldpos.z), Quaternion.Euler(Vector3.zero));
            var _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
            clone.transform.SetParent(_canvas.transform);

            //Return to original position and update Current Turn
            StartCoroutine(returnFromAttack()); 

        }

    }

    IEnumerator returnFromAttack()
    {
        //Wait
        yield return new WaitForSeconds(1);

        //Return player to old position
        GetComponent<Transform>().position = oldpos;

        //Let them attack you
        BattleFlowManager.ToggleBattefieldReady();

        //Destroy text clone
        Destroy(clone);
    }

}
