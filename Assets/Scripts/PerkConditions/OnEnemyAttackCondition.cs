using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyAttackCondition : PerkCondition
{
    public override bool SubConditionIsMet(GameAction gameAction)
    {
        //if attacker is.... return false
        return true;
    }

    public override void SubscribeCondition(Action<GameAction> reaction)
    {
        ActionSystem.SubscribeReaction<AttackHeroGA>(reaction, reactionTiming);
    }

    public override void UnsubscribeCondition(Action<GameAction> reaction)
    {
        ActionSystem.UnsubscribeReaction<AttackHeroGA>(reaction, reactionTiming);
    }
}
