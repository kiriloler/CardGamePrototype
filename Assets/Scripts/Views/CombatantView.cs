using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CombatantView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private StatusEffectsUI statusEffectsUI;
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    private Dictionary<StatusEffectType, int> statusEffects = new();
    protected void SetupBase(int health, Sprite image)
    {
        MaxHealth = CurrentHealth = health;
        spriteRenderer.sprite = image;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + CurrentHealth;
    }

    public void Damage(int damageAmount)
    {
        int remainingDamage = damageAmount;
        int currentArmor = GetStatusEffectStacks(StatusEffectType.ARMOR);
        if(currentArmor > 0)
        {
            if(currentArmor >= remainingDamage)
            {
                RemoveStatusEffect(StatusEffectType.ARMOR, remainingDamage);
                remainingDamage = 0;
            }else if(currentArmor < remainingDamage)
            {
                RemoveStatusEffect(StatusEffectType.ARMOR, currentArmor);
                remainingDamage -= currentArmor;
            }
        }
        if(remainingDamage > 0)
        {
            CurrentHealth -= remainingDamage;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
        transform.DOShakePosition(0.2f, 0.5f);
        UpdateHealthText();
    }
    public void AddStatusEffect(StatusEffectType type, int stackCount)
    {
        if (statusEffects.ContainsKey(type))
        {
            statusEffects[type] += stackCount;
        }
        else
        {
            statusEffects.Add(type, stackCount);
        }
        statusEffectsUI.UpdateStatusEffectUI(type, GetStatusEffectStacks(type));
    }
    public void RemoveStatusEffect(StatusEffectType type, int stackCount)
    {
        if (statusEffects.ContainsKey(type))
        {
            statusEffects[type] -= stackCount;
            if(statusEffects[type] == 0)
            {
                statusEffects.Remove(type);
            }
        }
        statusEffectsUI.UpdateStatusEffectUI(type, GetStatusEffectStacks(type));
    }
    public int GetStatusEffectStacks(StatusEffectType type)
    {
        if (statusEffects.ContainsKey(type)) return statusEffects[type];
        else return 0;
    }
}
