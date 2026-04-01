package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;

import java.util.List;
import java.util.Map;

public class CombatSimulation {
    private final BattleCoordinationContext context;
    private final GameActionExecutor executor;
    private final RelicRuntime relicRuntime;
    private final Map<String, SpireLinkCard> cards;

    public CombatSimulation(BattleCoordinationContext context, GameActionExecutor executor,
                            RelicRuntime relicRuntime, Map<String, SpireLinkCard> cards) {
        this.context = context;
        this.executor = executor;
        this.relicRuntime = relicRuntime;
        this.cards = cards;
    }

    public CardPlayResult playCard(String cardId, String actorId, String explicitTeammateTargetId, boolean upgraded) {
        SpireLinkCard card = cards.get(cardId);
        if (card == null) {
            throw new IllegalArgumentException("Unknown card: " + cardId);
        }
        CardPlayContext playContext = new CardPlayContext(
                context,
                actorId,
                null,
                context.enemyIds(),
                explicitTeammateTargetId,
                upgraded
        );
        return card.play(playContext, executor, relicRuntime);
    }

    public List<String> recentLogs() {
        return context.combatLog().stream().map(entry -> entry.type() + ":" + entry.detail()).toList();
    }
}
