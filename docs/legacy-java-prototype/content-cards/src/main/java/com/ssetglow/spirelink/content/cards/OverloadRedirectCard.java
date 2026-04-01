package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class OverloadRedirectCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "overload_redirect"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        executor.loseHp(context.battleContext(), context.actorId(), context.upgraded() ? 2 : 3, id(), result);
        executor.grantResonance(context.battleContext(), 3, id(), result);
        String target = executor.resolveTeammate(context.battleContext(), context.actorId(), TargetRule.NEXT_TEAMMATE, null);
        executor.enqueueLink(context.battleContext(), id(), context.actorId(), target, LinkEffectType.DRAW, 2, TargetRule.NEXT_TEAMMATE, 1, "draw 2 next turn", result);
        if (context.battleContext().resonanceState().reach(5)) {
            executor.gainEnergy(context.battleContext(), context.actorId(), 1, id(), result);
        }
    }
}
