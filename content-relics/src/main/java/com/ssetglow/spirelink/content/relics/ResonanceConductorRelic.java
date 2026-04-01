package com.ssetglow.spirelink.content.relics;

import com.ssetglow.spirelink.engine.SpireLinkRelic;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.domain.SupportActionRecord;

public class ResonanceConductorRelic implements SpireLinkRelic {
    @Override
    public String id() {
        return "resonance_conductor";
    }

    @Override
    public void onSupportAction(BattleCoordinationContext context, SupportActionRecord actionRecord, CardPlayResult result) {
        String flagKey = "relic:resonance_conductor:" + actionRecord.sourcePlayerId() + ":turn:" + context.turnCounters().getOrDefault(actionRecord.sourcePlayerId(), 0);
        if (!Boolean.TRUE.equals(context.tempFlags().get(flagKey))) {
            context.resonanceState().gain(1, id());
            context.tempFlags().put(flagKey, true);
            result.addResonanceGained(1);
            result.addEffect("Resonance Conductor grants +1 resonance");
        }
    }
}
