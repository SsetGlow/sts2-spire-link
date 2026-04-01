package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class FinaleOfAccordCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "finale_of_accord"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        executor.damageAllEnemies(context.battleContext(), context.enemyIds(), context.upgraded() ? 20 : 16, id(), result);
        if (context.battleContext().linkTriggeredThisTurn() >= 2 && context.battleContext().resonanceState().canSpend(5)) {
            int spent = executor.spendResonance(context.battleContext(), id(), 5, false, result);
            relicRuntime.onResonanceSpend(context.battleContext(), context.actorId(), spent, result);
            executor.damageAllEnemies(context.battleContext(), context.enemyIds(), context.upgraded() ? 15 : 12, id(), result);
            for (String playerId : context.battleContext().teamOrder()) {
                executor.gainBlock(context.battleContext(), playerId, context.upgraded() ? 6 : 5, id(), result);
            }
        }
    }
}
