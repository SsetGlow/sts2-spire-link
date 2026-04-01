package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.engine.SpireLinkCard;

import java.util.LinkedHashMap;
import java.util.Map;

public final class SpireLinkCardLibrary {
    private SpireLinkCardLibrary() {
    }

    public static Map<String, SpireLinkCard> createDefault() {
        Map<String, SpireLinkCard> cards = new LinkedHashMap<>();
        cards.put("linked_guard", new LinkedGuardCard());
        cards.put("target_mark", new TargetMarkCard());
        cards.put("resonance_prep", new ResonancePrepCard());
        cards.put("echo_circuit", new EchoCircuitCard());
        cards.put("resonant_strike", new ResonantStrikeCard());
        cards.put("chain_repair", new ChainRepairCard());
        cards.put("overload_redirect", new OverloadRedirectCard());
        cards.put("finale_of_accord", new FinaleOfAccordCard());
        return cards;
    }
}
