using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,  // Start the battle
    PlayerTurn,   // player action
    EnemyTurn,   // enemy action
    FinishedTurn,  // all turns finished
    Won,   // no enemies left
    Lost   // PLaer Dead
}
public class TurnHandle : MonoBehaviour
{
    public BattleState state;

    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;

    public GameObject PlayerUi;
    public HeartCtrl PlayerHeart;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( state == BattleState.Start)
        {
            // Set up the level 
            PlayerUi.SetActive(true);
            state = BattleState.PlayerTurn;

            // For each enemy in the enemy profile list, create an animated sprite for them
            // set this enemies health and charm hp to the profiles health and charm hp
        }
        else if (state == BattleState.PlayerTurn)
        {
            // wait for player to attack
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (EnemiesInBattle.Length <= 0)
            {
                // there are no enemies so finish the enemy turn
                EnemyFinishedTurn();
            }
            else
            {
                if (!enemyActed)
                {
                    //turn on the player heart
                    PlayerHeart.gameObject.SetActive(true);
                    PlayerHeart.SetHeart();

                    // create all battle effects in the enemy logics
                    foreach (EnemyProfile emy in EnemiesInBattle)
                    {
                        int AtkNumb = Random.Range(0, emy.EnemiesAttacks.Length);

                        Instantiate(emy.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
                    }

                    // find all attacks in scene to check when there done 
                    EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");

                    enemyActed = true;
                }
                else
                {
                    bool enemyfin = true;
                    foreach (GameObject emy in EnemyAtks)
                    {
                        if (!emy.GetComponent<EnemyTurnHandle>().FinishedTurn)
                        {
                            enemyfin = false;
                        }
                    }

                    if (enemyfin)
                    {
                        EnemyFinishedTurn();
                    }
                }
            }
            // enemy take turn
        }
        else if (state == BattleState.FinishedTurn)
        {
            // turn is over turn off the player heart
            PlayerHeart.gameObject.SetActive(false);

            // check if the player is alive at the end of turn
            if (PlayerHeart.GetComponent<PlayerHealth>().HP < 0)
            {
                state = BattleState.Lost;
            }
            else
            {
                // if enemy health at 0 won
                state = BattleState.Start;
            }
        }
        else if (state == BattleState.Won)
        {

        }
    }

    public void PlayerAct()
    {
        // bring up the menu of additional player actions that will target specific enemies

        playerfinishTurn();
    }

    void playerfinishTurn()
    {
        // once the players turn has ended
        PlayerUi.SetActive(false);

        state = BattleState.EnemyTurn;
    }

    void EnemyFinishedTurn()
    {
        // destroy all attacks
        foreach(GameObject obj in EnemyAtks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }
}
