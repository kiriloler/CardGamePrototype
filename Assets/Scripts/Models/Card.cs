using UnityEngine;
using System.Collections.Generic;

public class Card
{
    //卡片属性的构造
    private readonly CardData data;
    public string Title => data.name;
    public string Description => data.Description;
    public Sprite Image => data.Image;
    public Effect ManualTargetEffect => data.ManualTargetEffect;
    public List<AutoTargetEffect> OtherEffects => data.OtherEffects;
    public int Mana { get; private set; }
    
    public Card(CardData cardData)
    {
        data = cardData;
        Mana = cardData.Mana;
    }
}
