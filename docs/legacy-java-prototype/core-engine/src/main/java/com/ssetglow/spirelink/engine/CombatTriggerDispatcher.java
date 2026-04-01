package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.SupportActionRecord;

import java.util.List;

public class CombatTriggerDispatcher {
    private final LinkResolver linkResolver;

    public CombatTriggerDispatcher(LinkResolver linkResolver) {
        this.linkResolver = linkResolver;
    }

    public List<SupportActionRecord> onTurnStart(BattleCoordinationContext context, String playerId) {
        context.incrementTurn(playerId);
        context.resetTurnScopedCounters();
        int currentTurn = context.turnCounters().getOrDefault(playerId, 1);
        return linkResolver.triggerTurnStartLinks(context, playerId, currentTurn);
    }
}
