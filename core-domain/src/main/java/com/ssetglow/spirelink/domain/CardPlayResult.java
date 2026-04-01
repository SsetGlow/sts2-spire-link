package com.ssetglow.spirelink.domain;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CardPlayResult {
    private final String cardId;
    private final String actorId;
    private final List<String> appliedEffects = new ArrayList<>();
    private int resonanceGained;
    private int resonanceSpent;
    private int totalDamage;

    public CardPlayResult(String cardId, String actorId) {
        this.cardId = cardId;
        this.actorId = actorId;
    }

    public String cardId() { return cardId; }
    public String actorId() { return actorId; }
    public List<String> appliedEffects() { return Collections.unmodifiableList(appliedEffects); }
    public int resonanceGained() { return resonanceGained; }
    public int resonanceSpent() { return resonanceSpent; }
    public int totalDamage() { return totalDamage; }

    public void addEffect(String text) { appliedEffects.add(text); }
    public void addResonanceGained(int value) { resonanceGained += Math.max(0, value); }
    public void addResonanceSpent(int value) { resonanceSpent += Math.max(0, value); }
    public void addDamage(int value) { totalDamage += Math.max(0, value); }
}
