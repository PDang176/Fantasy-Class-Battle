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

    void TakeDamage(int damage)
	{
        current_health -= damage;
        health_bar.SetHealth(current_health);
	}

    public void Attack()
	{
        enemy.TakeDamage(ATK - enemy.DEF);
	}
}