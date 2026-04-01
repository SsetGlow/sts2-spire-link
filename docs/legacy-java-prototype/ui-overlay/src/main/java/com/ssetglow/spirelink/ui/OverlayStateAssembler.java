package com.ssetglow.spirelink.ui;

import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.ResonanceHistory;

import java.util.Comparator;

public class OverlayStateAssembler {
    public ResonanceBarViewModel resonanceBar(BattleCoordinationContext context) {
        String lastGain = context.resonanceState().history().stream()
                .filter(item -> item.delta() > 0)
                .max(Comparator.comparing(ResonanceHistory::occurredAt))
                .map(ResonanceHistory::source)
                .orElse(null);
        String lastSpend = context.resonanceState().history().stream()
                .filter(item -> item.delta() < 0)
                .max(Comparator.comparing(ResonanceHistory::occurredAt))
                .map(ResonanceHistory::source)
                .orElse(null);
        return new ResonanceBarViewModel(context.resonanceState().current(), context.resonanceState().max(), lastGain, lastSpend);
    }
}
