package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class ResonantStrikeCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "resonant_strike"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        int baseDamage = context.upgraded() ? 18 : 14;
        int bonusPerResonance = context.upgraded() ? 6 : 5;
        int spent = Math.min(3, context.battleContext().resonanceState().current());
        spent = executor.spendResonance(context.battleContext(), id(), spent, true, result);
        if (spent > 0) {
            relicRuntime.onResonanceSpend(context.battleContext(), context.actorId(), spent, result);
        }
        String target = context.primaryTargetId() != null ? context.primaryTargetId() : context.enemyIds().getFirst();
        executor.damageEnemy(context.battleContext(), target, baseDamage + (spent * bonusPerResonance), id(), result);
    }
}
