package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;

public class TargetMarkCard extends AbstractSpireLinkCard {
    @Override
    public String id() { return "target_mark"; }

    @Override
    protected void doPlay(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime, CardPlayResult result) {
        int vulnerable = context.upgraded() ? 2 : 1;
        int attackBonus = context.upgraded() ? 6 : 4;
        executor.applyVulnerableToAll(context.battleContext(), context.enemyIds(), vulnerable, id(), result);
        String target = executor.resolveTeammate(context.battleContext(), context.actorId(), TargetRule.NEXT_TEAMMATE, null);
        executor.enqueueLink(context.battleContext(), id(), context.actorId(), target, LinkEffectType.ATTACK_BONUS, attackBonus, TargetRule.NEXT_TEAMMATE, 1, "grant attack bonus", result);
        executor.grantResonance(context.battleContext(), 1, id(), result);
    }
}
