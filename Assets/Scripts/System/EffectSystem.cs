using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSystem : Singleton<EffectSystem>
{
    void OnEnable()
    {
        ActionSystem.AttachPerformer<PerformEffectsGA>(PerformEffectPerformer);
    }

    void OnDisable()
    {
        ActionSystem.DetachPerformer<PerformEffectsGA>();
    }
    //performers
    private IEnumerator PerformEffectPerformer(PerformEffectsGA performEffectsGA)
    {
        GameAction effectAction = performEffectsGA.Effect.GetGameAction(performEffectsGA.Targets, HeroSystem.Instance.HeroView);
        ActionSystem.Instance.AddReaction(effectAction);
        yield return null;
    }
}
