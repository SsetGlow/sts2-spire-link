package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.SupportActionType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.domain.SupportActionRecord;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class ChainRepairCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "chain_repair"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        String target = context.explicitTeammateTargetId() != null
                ? context.explicitTeammateTargetId()
                : executor.resolveTeammate(context.battleContext(), context.actorId(), TargetRule.NEXT_TEAMMATE, null);
        int cleansed = context.battleContext().requirePlayer(target).cleansedDebuffs();
        SupportActionRecord record;
        if (cleansed == 0) {
            record = executor.applySupportAction(context.battleContext(), context.actorId(), target, id(), SupportActionType.GRANT_BLOCK, context.upgraded() ? 11 : 8, result);
        } else {
            record = executor.applySupportAction(context.battleContext(), context.actorId(), target, id(), SupportActionType.CLEANSE_DEBUFF, 1, result);
            if (context.upgraded()) {
                executor.queueDraw(context.battleContext(), target, 1, id(), result);
            }
        }
        relicRuntime.onSupportAction(context.battleContext(), record, result);
        executor.grantResonance(context.battleContext(), 2, id(), result);
    }
}
