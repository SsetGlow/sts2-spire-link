package com.ssetglow.spirelink.domain;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Queue;

public class BattleCoordinationContext {
    private final TeamResonanceState resonanceState;
    private final Queue<LinkEffect> pendingLinks;
    private final Map<String, Integer> turnCounters;
    private final Map<String, Object> tempFlags;
    private final Map<String, PlayerState> players;
    private final List<String> teamOrder;
    private final List<SupportActionRecord> supportActionRecords;
    private int linkTriggeredThisTurn;

    public BattleCoordinationContext(List<String> teamOrder) {
        this.resonanceState = new TeamResonanceState();
        this.pendingLinks = new ArrayDeque<>();
        this.turnCounters = new HashMap<>();
        this.tempFlags = new HashMap<>();
        this.players = new LinkedHashMap<>();
        this.teamOrder = new ArrayList<>(teamOrder);
        this.supportActionRecords = new ArrayList<>();
        teamOrder.forEach(id -> players.put(id, new PlayerState(id, 100)));
    }

    public TeamResonanceState resonanceState() { return resonanceState; }
    public Queue<LinkEffect> pendingLinks() { return pendingLinks; }
    public Map<String, Integer> turnCounters() { return turnCounters; }
    public Map<String, Object> tempFlags() { return tempFlags; }
    public Map<String, PlayerState> players() { return Collections.unmodifiableMap(players); }
    public List<String> teamOrder() { return Collections.unmodifiableList(teamOrder); }
    public List<SupportActionRecord> supportActionRecords() { return Collections.unmodifiableList(supportActionRecords); }
    public int linkTriggeredThisTurn() { return linkTriggeredThisTurn; }

    public PlayerState requirePlayer(String playerId) {
        PlayerState state = players.get(playerId);
        if (state == null) {
            throw new IllegalArgumentException("Unknown player: " + playerId);
        }
        return state;
    }

    public void enqueueLink(LinkEffect effect) {
        pendingLinks.add(Objects.requireNonNull(effect));
    }

    public void recordSupport(SupportActionRecord record) {
        supportActionRecords.add(record);
    }

    public void incrementTurn(String playerId) {
        turnCounters.merge(playerId, 1, Integer::sum);
    }

    public void incrementLinkTriggeredThisTurn() {
        linkTriggeredThisTurn++;
    }

    public void resetTurnScopedCounters() {
        linkTriggeredThisTurn = 0;
    }
}
