package com.ssetglow.spirelink.domain;

public class EnemyState {
    private final String enemyId;
    private int hp;
    private int vulnerable;
    private int strength;
    private int pendingDamage;

    public EnemyState(String enemyId, int hp) {
        this.enemyId = enemyId;
        this.hp = hp;
    }

    public String enemyId() { return enemyId; }
    public int hp() { return hp; }
    public int vulnerable() { return vulnerable; }
    public int strength() { return strength; }
    public int pendingDamage() { return pendingDamage; }

    public void takeDamage(int value) {
        int actual = Math.max(0, value);
        hp -= actual;
        pendingDamage += actual;
    }

    public void applyVulnerable(int layers) { vulnerable += Math.max(0, layers); }
    public void gainStrength(int value) { strength += Math.max(0, value); }
    public void clearPendingDamage() { pendingDamage = 0; }
}
