package com.ssetglow.spirelink.content.relics;

import com.ssetglow.spirelink.engine.SpireLinkRelic;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayResult;

public class CommandCoreRelic implements SpireLinkRelic {
    @Override
    public String id() {
        return "command_core";
    }

    @Override
    public void onResonanceSpend(BattleCoordinationContext context, String playerId, int spentAmount, CardPlayResult result) {
        String flagKey = "relic:command_core:turn:" + context.turnCounters().getOrDefault(playerId, 0);
        if (Boolean.TRUE.equals(context.tempFlags().get(flagKey))) {
            return;
        }
        context.tempFlags().put(flagKey, true);
        context.requirePlayer(playerId).gainBlock(4);
        result.addEffect("Command Core grants 4 block to " + playerId);
        context.teamOrder().stream().filter(id -> !id.equals(playerId)).findFirst().ifPresent(other -> {
            context.requirePlayer(other).queueDraw(1);
            result.addEffect("Command Core grants 1 draw to " + other);
        });
        if (spentAmount >= 4) {
            context.resonanceState().gain(1, id());
            result.addResonanceGained(1);
            result.addEffect("Command Core refunds 1 resonance");
        }
    }
}
