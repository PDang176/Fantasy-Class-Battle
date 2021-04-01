using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string player_class;
    public int ATK;
    public int DEF;
    public int AGI;
    public int current_health;
    public int max_health = 0;

    public HealthBar health_bar;
    public Text class_text;
    public Text ATK_text;
    public Text DEF_text;
    public Text AGI_text;
    public Button attack_button;
    public Button end_turn_button;

    public BattleSystem bs;

    public Player enemy;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        health_bar.SetMaxHealth(max_health);

        class_text.text = player_class;
        ATK_text.text = "ATK: " + ATK.ToString();
        DEF_text.text = "DEF: " + DEF.ToString();
        AGI_text.text = "AGI: " + AGI.ToString();
    }

    public void SetStats(string player_class, int max_health, int ATK, int DEF, int AGI)
	{
        this.player_class = player_class;
        this.max_health = max_health;
        this.ATK = ATK;
        this.DEF = DEF;
        this.AGI = AGI;
	}

    public void SetEnemy(Player enemy)
	{
        this.enemy = enemy;
	}

    public void SetBattleSystem(BattleSystem bs)
	{
        this.bs = bs;
	}

    void TakeDamage(int damage)
	{
        if(damage <= 0)
		{
            return;
		}
        current_health -= damage;
        health_bar.SetHealth(current_health);
	}

    public void Attack()
	{
        if(this.AGI > enemy.AGI)
		{
            enemy.TakeDamage(this.ATK * 2 - enemy.DEF);
		}
        else if(this.AGI < enemy.AGI)
		{
            enemy.TakeDamage(this.ATK - enemy.DEF * 2);
		}
		else
        {
            enemy.TakeDamage(ATK - enemy.DEF);
        }
        attack_button.interactable = false;
	}

    public void EndTurn()
	{
        bs.EndTurn();
	}

    public void DisableButtons()
	{
        attack_button.interactable = false;
        end_turn_button.interactable = false;
    }

    public void EnableButtons()
	{
        attack_button.interactable = true;
        end_turn_button.interactable = true;
    }
}