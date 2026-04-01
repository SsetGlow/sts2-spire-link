package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;

public class EventChoiceProcessor {
    private final ResonanceManager resonanceManager;

    public EventChoiceProcessor(ResonanceManager resonanceManager) {
        this.resonanceManager = resonanceManager;
    }

    public void processAltarOfSyncChoice(BattleCoordinationContext context, String choiceCode) {
        switch (choiceCode) {
            case "A" -> {
                resonanceManager.gain(context, 3, "event:altar_of_sync:build_resonance");
                context.tempFlags().put("altar.enemyStrengthForNextBattles", 2);
                context.tempFlags().put("altar.rewardRelic", "resonance_conductor");
            }
            case "B" -> {
                context.tempFlags().put("altar.doubleFirstLinkNextBattle", true);
                context.tempFlags().put("altar.injectBurdenCard", true);
            }
            case "C" -> context.players().values().forEach(player -> context.requirePlayer(player.playerId()).heal(5));
            default -> throw new IllegalArgumentException("Unknown event choice: " + choiceCode);
        }
    }
}
