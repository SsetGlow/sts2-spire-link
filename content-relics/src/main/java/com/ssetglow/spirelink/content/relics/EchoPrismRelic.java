package com.ssetglow.spirelink.content.relics;

import com.ssetglow.spirelink.common.SupportActionType;
import com.ssetglow.spirelink.engine.SpireLinkRelic;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.domain.SupportActionRecord;

public class EchoPrismRelic implements SpireLinkRelic {
    @Override
    public String id() {
        return "echo_prism";
    }

    @Override
    public void onSupportAction(BattleCoordinationContext context, SupportActionRecord actionRecord, CardPlayResult result) {
        if (actionRecord.actionType() == SupportActionType.GRANT_BLOCK || actionRecord.actionType() == SupportActionType.PROTECT) {
            context.requirePlayer(actionRecord.targetPlayerId()).gainBlock(3);
            result.addEffect("Echo Prism grants extra 3 block to " + actionRecord.targetPlayerId());
        } else if (actionRecord.actionType() == SupportActionType.GRANT_DRAW) {
            context.requirePlayer(actionRecord.targetPlayerId()).addAttackBonus(3);
            result.addEffect("Echo Prism grants +3 next attack damage to " + actionRecord.targetPlayerId());
        } else {
            context.requirePlayer(actionRecord.targetPlayerId()).queueDraw(1);
            result.addEffect("Echo Prism grants +1 draw to " + actionRecord.targetPlayerId());
        }
    }
}
