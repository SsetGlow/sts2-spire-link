package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class ResonancePrepCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "resonance_prep"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        executor.queueDraw(context.battleContext(), context.actorId(), context.upgraded() ? 2 : 1, id(), result);
        String target = executor.resolveTeammate(context.battleContext(), context.actorId(), TargetRule.NEXT_TEAMMATE, null);
        executor.enqueueLink(context.battleContext(), id(), context.actorId(), target, LinkEffectType.COST_REDUCTION, 1, TargetRule.NEXT_TEAMMATE, 1, "reduce first card cost by 1", result);
        executor.grantResonance(context.battleContext(), 1, id(), result);
    }
}
