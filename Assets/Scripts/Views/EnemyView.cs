using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyView : CombatantView
{
    [SerializeField] private TMP_Text attackText;
    public int AttackPower { get; set; }
    public void Setup(EnemyData enemyData)
    {
        AttackPower = enemyData.AttackPower;
        UpdateAttackText();
        SetupBase(enemyData.Health, enemyData.Image);
    }
    private void UpdateAttackText()
    {
        attackText.text = "ATK: " + AttackPower;
    }
}
