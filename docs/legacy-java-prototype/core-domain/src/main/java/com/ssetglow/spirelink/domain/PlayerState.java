package com.ssetglow.spirelink.domain;

public class PlayerState {
    private final String playerId;
    private int hp;
    private int block;
    private int energy;
    private int pendingAttackBonus;
    private int nextCardCostReduction;
    private int drawQueued;
    private int cleansedDebuffs;

    public PlayerState(String playerId, int hp) {
        this.playerId = playerId;
        this.hp = hp;
    }

    public String playerId() { return playerId; }
    public int hp() { return hp; }
    public int block() { return block; }
    public int energy() { return energy; }
    public int pendingAttackBonus() { return pendingAttackBonus; }
    public int nextCardCostReduction() { return nextCardCostReduction; }
    public int drawQueued() { return drawQueued; }
    public int cleansedDebuffs() { return cleansedDebuffs; }

    public void loseHp(int value) { hp -= Math.max(0, value); }
    public void heal(int value) { hp += Math.max(0, value); }
    public void gainBlock(int value) { block += Math.max(0, value); }
    public void gainEnergy(int value) { energy += Math.max(0, value); }
    public void queueDraw(int value) { drawQueued += Math.max(0, value); }
    public void addAttackBonus(int value) { pendingAttackBonus += Math.max(0, value); }
    public void reduceNextCardCost(int value) { nextCardCostReduction += Math.max(0, value); }
    public void cleanseDebuff(int count) { cleansedDebuffs += Math.max(0, count); }
}
