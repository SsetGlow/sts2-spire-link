package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.ResonanceSpendRequest;

public class ResonanceManager {
    public int gain(BattleCoordinationContext context, int amount, String source) {
        return context.resonanceState().gain(amount, source);
    }

    public int spend(BattleCoordinationContext context, ResonanceSpendRequest request) {
        if (!request.optional() && !context.resonanceState().canSpend(request.requestedAmount())) {
            throw new IllegalStateException("Not enough resonance for: " + request.sourceId());
        }
        return context.resonanceState().spend(request.requestedAmount(), request.sourceId());
    }

    public boolean reaches(BattleCoordinationContext context, int threshold) {
        return context.resonanceState().reach(threshold);
    }
}
