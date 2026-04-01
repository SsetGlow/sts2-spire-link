package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.ResonanceConstants;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class EchoCircuitCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "echo_circuit"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        executor.gainBlock(context.battleContext(), context.actorId(), context.upgraded() ? 10 : 8, id(), result);
        if (executor.resonanceAtLeast(context.battleContext(), ResonanceConstants.COMMON_THRESHOLD)) {
            executor.queueDraw(context.battleContext(), context.actorId(), 2, id(), result);
        }
        if (context.explicitTeammateTargetId() != null && context.battleContext().resonanceState().canSpend(3)) {
            int spent = executor.spendResonance(context.battleContext(), id(), 3, true, result);
            if (spent > 0) {
                relicRuntime.onResonanceSpend(context.battleContext(), context.actorId(), spent, result);
                executor.queueDraw(context.battleContext(), context.explicitTeammateTargetId(), 1, id(), result);
            }
        }
    }
}
