package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.domain.SupportActionRecord;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class RelicRuntime {
    private final List<SpireLinkRelic> relics = new ArrayList<>();

    public RelicRuntime(List<SpireLinkRelic> relics) {
        if (relics != null) {
            this.relics.addAll(relics);
        }
    }

    public List<SpireLinkRelic> relics() {
        return Collections.unmodifiableList(relics);
    }

    public void onSupportAction(BattleCoordinationContext context, SupportActionRecord actionRecord, CardPlayResult result) {
        for (SpireLinkRelic relic : relics) {
            relic.onSupportAction(context, actionRecord, result);
        }
    }

    public void onResonanceSpend(BattleCoordinationContext context, String playerId, int spentAmount, CardPlayResult result) {
        for (SpireLinkRelic relic : relics) {
            relic.onResonanceSpend(context, playerId, spentAmount, result);
        }
    }
}
