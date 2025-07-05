using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PerkCondition
{
    [SerializeField] protected ReactionTiming reactionTiming;
    public abstract void SubscribeCondition(Action<GameAction> reaction);
    public abstract void UnsubscribeCondition(Action<GameAction> reaction);
    public abstract bool SubConditionIsMet(GameAction gameAction);
}
