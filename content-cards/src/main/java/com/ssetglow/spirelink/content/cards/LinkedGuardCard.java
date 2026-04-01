package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class LinkedGuardCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "linked_guard"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        int selfBlock = context.upgraded() ? 9 : 7;
        int teamBlock = context.upgraded() ? 7 : 5;
        executor.gainBlock(context.battleContext(), context.actorId(), selfBlock, id(), result);
        String target = executor.resolveTeammate(context.battleContext(), context.actorId(), TargetRule.NEXT_TEAMMATE, null);
        executor.enqueueLink(context.battleContext(), id(), context.actorId(), target, LinkEffectType.BLOCK, teamBlock, TargetRule.NEXT_TEAMMATE, 1, "grant block", result);
        executor.grantResonance(context.battleContext(), 1, id(), result);
    }
}
