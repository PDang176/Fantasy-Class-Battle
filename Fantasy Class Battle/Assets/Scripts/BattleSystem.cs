using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYER_ONE_TURN, PLAYER_TWO_TURN, PLAYER_ONE_WIN, PLAYER_TWO_WIN } 

public class BattleSystem : MonoBehaviour
{
    public Transform playerOneLoc;
    public Transform playerTwoLoc;

    Player playerOne;
    Player playerTwo;

    public Image borderOne;
    public Image borderTwo;

    public BattleState state;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        round = 2;
        SetupBattle("Knight", "Assassin");
    }

    void SetupBattle(string p1, string p2)
    {
        GameObject playerOneGo = Instantiate((GameObject)Resources.Load(p1), playerOneLoc);
        playerOne = playerOneGo.GetComponent<Player>();

        GameObject playerTwoGo = Instantiate((GameObject)Resources.Load(p2), playerTwoLoc);
        playerTwo = playerTwoGo.GetComponent<Player>();

        playerOne.SetEnemy(playerTwo);
        playerTwo.SetEnemy(playerOne);

        playerOne.SetBattleSystem(this);
        playerTwo.SetBattleSystem(this);

        state = CheckTurn();
    }

    BattleState CheckTurn()
	{
        round = 2;

        if(playerOne.AGI > playerTwo.AGI)
		{
            borderOne.color = Color.yellow;
            borderTwo.color = Color.blue;
            playerOne.EnableButtons();
            playerTwo.DisableButtons();
            return BattleState.PLAYER_ONE_TURN;
		}
		else
		{
            borderOne.color = Color.blue;
            borderTwo.color = Color.yellow;
            playerOne.DisableButtons();
            playerTwo.EnableButtons();
            return BattleState.PLAYER_TWO_TURN;
		}
	}

    public void EndTurn()
	{
        round--;
        if(round <= 0)
		{
            state = CheckTurn();
		}
		else if(state == BattleState.PLAYER_ONE_TURN)
		{
            borderOne.color = Color.white;
            borderTwo.color = Color.yellow;
            playerOne.DisableButtons();
            playerTwo.EnableButtons();
            state = BattleState.PLAYER_TWO_TURN;
		}
        else if(state == BattleState.PLAYER_TWO_TURN)
		{
            borderOne.color = Color.yellow;
            borderTwo.color = Color.white;
            playerOne.EnableButtons();
            playerTwo.DisableButtons();
            state = BattleState.PLAYER_ONE_TURN;
		}
	}
}
