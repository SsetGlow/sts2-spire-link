package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.CardPlayResult;
import com.ssetglow.spirelink.domain.SupportActionRecord;

public interface SpireLinkRelic {
    String id();

    default void onSupportAction(BattleCoordinationContext context, SupportActionRecord actionRecord, CardPlayResult result) {
    }

    default void onResonanceSpend(BattleCoordinationContext context, String playerId, int spentAmount, CardPlayResult result) {
    }
}
