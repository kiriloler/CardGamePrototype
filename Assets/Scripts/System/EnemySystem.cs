using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySystem : Singleton<EnemySystem>
{
    [SerializeField] EnemyBoardView enemyBoardView;
    public List<EnemyView> Enemies => enemyBoardView.EnemyViews;
    void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
        ActionSystem.AttachPerformer<AttackHeroGA>(AttackHeroPerformer);
        ActionSystem.AttachPerformer<KillEnemyGA>(KillEnemyPerformer);
    }

    void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
        ActionSystem.DetachPerformer<AttackHeroGA>();
        ActionSystem.DetachPerformer<KillEnemyGA>();
    }
    //setting up enemies
    public void Setup(List<EnemyData> enemyDatas)
    {
        foreach(var enemyData in enemyDatas)
        {
            enemyBoardView.AddEnemy(enemyData);
        }
    }

    //Performers

    private IEnumerator EnemyTurnPerformer(EnemyTurnGA enemyTurnGA)
    {
        foreach(var enemy in enemyBoardView.EnemyViews)
        {
            AttackHeroGA attackHeroGA = new(enemy);
            ActionSystem.Instance.AddReaction(attackHeroGA);
        }
        yield return null;
    }
    private IEnumerator AttackHeroPerformer(AttackHeroGA attackHeroGA)
    {
        EnemyView attacker = attackHeroGA.Attacker;
        Tween tween = attacker.transform.DOMoveX(attacker.transform.position.x - 1f, 0.15f);
        yield return tween.WaitForCompletion();
        attacker.transform.DOMoveX(attacker.transform.position.x + 1f, 0.25f);
        //deal damage
        DealDamageGA dealDamageGA = new(attacker.AttackPower, new() { HeroSystem.Instance.HeroView }, attackHeroGA.Caster);
        ActionSystem.Instance.AddReaction(dealDamageGA);
    }
    private IEnumerator KillEnemyPerformer(KillEnemyGA killEnemyGA)
    {
        yield return enemyBoardView.RemoveEnemy(killEnemyGA.EnemyView);
    }
}
