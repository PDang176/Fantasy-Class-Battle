using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public enum BattleState { START, PLAYER_ONE, PLAYER_TWO, PLAYER_ONE_WIN, PLAYER_TWO_WIN } 

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public Player playerOne;
    public Player playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle("Knight", "Assassin");
    }

    void SetupBattle(string p1, string p2)
    {
        string playerOnePath = Application.streamingAssetsPath + "/Classes/" + p1 + ".txt";
        string playerTwoPath = Application.streamingAssetsPath + "/Classes/" + p2 + ".txt";

        List<string> p1FileLines = File.ReadAllLines(playerOnePath).ToList();
        playerOne.SetStats(p1FileLines[0], int.Parse(p1FileLines[1]), int.Parse(p1FileLines[2]), int.Parse(p1FileLines[3]), int.Parse(p1FileLines[4]));

        List<string> p2FileLines = File.ReadAllLines(playerTwoPath).ToList();
        playerTwo.SetStats(p2FileLines[0], int.Parse(p2FileLines[1]), int.Parse(p2FileLines[2]), int.Parse(p2FileLines[3]), int.Parse(p2FileLines[4]));
    }
}
