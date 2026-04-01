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
    private final Map<String, EnemyState> enemies;
    private final List<String> teamOrder;
    private final List<SupportActionRecord> supportActionRecords;
    private final List<CombatLogEntry> combatLog;
    private int linkTriggeredThisTurn;

    public BattleCoordinationContext(List<String> teamOrder) {
        this(teamOrder, List.of("enemy-1"));
    }

    public BattleCoordinationContext(List<String> teamOrder, List<String> enemyIds) {
        this.resonanceState = new TeamResonanceState();
        this.pendingLinks = new ArrayDeque<>();
        this.turnCounters = new HashMap<>();
        this.tempFlags = new HashMap<>();
        this.players = new LinkedHashMap<>();
        this.enemies = new LinkedHashMap<>();
        this.teamOrder = new ArrayList<>(teamOrder);
        this.supportActionRecords = new ArrayList<>();
        this.combatLog = new ArrayList<>();
        teamOrder.forEach(id -> players.put(id, new PlayerState(id, 100)));
        enemyIds.forEach(id -> enemies.put(id, new EnemyState(id, 100)));
    }

    public TeamResonanceState resonanceState() { return resonanceState; }
    public Queue<LinkEffect> pendingLinks() { return pendingLinks; }
    public Map<String, Integer> turnCounters() { return turnCounters; }
    public Map<String, Object> tempFlags() { return tempFlags; }
    public Map<String, PlayerState> players() { return Collections.unmodifiableMap(players); }
    public Map<String, EnemyState> enemies() { return Collections.unmodifiableMap(enemies); }
    public List<String> teamOrder() { return Collections.unmodifiableList(teamOrder); }
    public List<String> enemyIds() { return List.copyOf(enemies.keySet()); }
    public List<SupportActionRecord> supportActionRecords() { return Collections.unmodifiableList(supportActionRecords); }
    public List<CombatLogEntry> combatLog() { return Collections.unmodifiableList(combatLog); }
    public int linkTriggeredThisTurn() { return linkTriggeredThisTurn; }

    public PlayerState requirePlayer(String playerId) {
        PlayerState state = players.get(playerId);
        if (state == null) {
            throw new IllegalArgumentException("Unknown player: " + playerId);
        }
        return state;
    }

    public EnemyState requireEnemy(String enemyId) {
        EnemyState state = enemies.get(enemyId);
        if (state == null) {
            throw new IllegalArgumentException("Unknown enemy: " + enemyId);
        }
        return state;
    }

    public void enqueueLink(LinkEffect effect) {
        pendingLinks.add(Objects.requireNonNull(effect));
    }

    public void recordSupport(SupportActionRecord record) {
        supportActionRecords.add(record);
    }

    public void appendLog(CombatLogEntry entry) {
        combatLog.add(Objects.requireNonNull(entry));
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
