package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.SupportActionType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.domain.*;

import java.util.List;

public class GameActionExecutor {
    private final ResonanceManager resonanceManager;
    private final TeamTargetResolver targetResolver;
    private final LinkResolver linkResolver;

    public GameActionExecutor(ResonanceManager resonanceManager, TeamTargetResolver targetResolver, LinkResolver linkResolver) {
        this.resonanceManager = resonanceManager;
        this.targetResolver = targetResolver;
        this.linkResolver = linkResolver;
    }

    public int gainBlock(BattleCoordinationContext context, String playerId, int amount, String source, CardPlayResult result) {
        context.requirePlayer(playerId).gainBlock(amount);
        result.addEffect(playerId + " gains " + amount + " block");
        context.appendLog(CombatLogEntry.now("block", source, playerId + "+" + amount));
        return amount;
    }

    public int loseHp(BattleCoordinationContext context, String playerId, int amount, String source, CardPlayResult result) {
        context.requirePlayer(playerId).loseHp(amount);
        result.addEffect(playerId + " loses " + amount + " HP");
        context.appendLog(CombatLogEntry.now("hp_loss", source, playerId + "-" + amount));
        return amount;
    }

    public int gainEnergy(BattleCoordinationContext context, String playerId, int amount, String source, CardPlayResult result) {
        context.requirePlayer(playerId).gainEnergy(amount);
        result.addEffect(playerId + " gains " + amount + " energy");
        context.appendLog(CombatLogEntry.now("energy", source, playerId + "+" + amount));
        return amount;
    }

    public int queueDraw(BattleCoordinationContext context, String playerId, int amount, String source, CardPlayResult result) {
        context.requirePlayer(playerId).queueDraw(amount);
        result.addEffect(playerId + " draws " + amount + " next available cards");
        context.appendLog(CombatLogEntry.now("draw", source, playerId + "+" + amount));
        return amount;
    }

    public int grantResonance(BattleCoordinationContext context, int amount, String source, CardPlayResult result) {
        int gained = resonanceManager.gain(context, amount, source);
        result.addResonanceGained(gained);
        result.addEffect("team resonance +" + gained);
        return gained;
    }

    public int spendResonance(BattleCoordinationContext context, String source, int amount, boolean optional, CardPlayResult result) {
        int spent = resonanceManager.spend(context, new ResonanceSpendRequest(source, amount, optional));
        result.addResonanceSpent(spent);
        if (spent > 0) {
            result.addEffect("team resonance -" + spent);
        }
        return spent;
    }

    public boolean resonanceAtLeast(BattleCoordinationContext context, int threshold) {
        return resonanceManager.reaches(context, threshold);
    }

    public SupportActionRecord applySupportAction(BattleCoordinationContext context, String sourcePlayerId, String targetPlayerId,
                                                  String sourceCardId, SupportActionType actionType, int value,
                                                  CardPlayResult result) {
        switch (actionType) {
            case GRANT_BLOCK, PROTECT -> gainBlock(context, targetPlayerId, value, sourceCardId, result);
            case GRANT_DRAW -> queueDraw(context, targetPlayerId, value, sourceCardId, result);
            case REDUCE_COST -> context.requirePlayer(targetPlayerId).reduceNextCardCost(value);
            case CLEANSE_DEBUFF -> context.requirePlayer(targetPlayerId).cleanseDebuff(value);
            case GRANT_ATTACK_BONUS -> context.requirePlayer(targetPlayerId).addAttackBonus(value);
        }
        SupportActionRecord record = SupportActionRecord.now(sourcePlayerId, targetPlayerId, sourceCardId, actionType, value);
        context.recordSupport(record);
        context.appendLog(CombatLogEntry.now("support", sourceCardId, actionType + " -> " + targetPlayerId + " value=" + value));
        return record;
    }

    public String resolveTeammate(BattleCoordinationContext context, String sourcePlayerId, TargetRule rule, String explicitTargetId) {
        return targetResolver.resolve(context, sourcePlayerId, rule, explicitTargetId).playerId();
    }

    public void enqueueLink(BattleCoordinationContext context, String cardId, String sourcePlayerId, String targetPlayerId,
                            LinkEffectType effectType, int value, TargetRule targetRule, int expireTurn, String description,
                            CardPlayResult result) {
        context.enqueueLink(linkResolver.createEffect(cardId, sourcePlayerId, targetPlayerId, effectType, value, targetRule, expireTurn, description));
        result.addEffect("link queued for " + targetPlayerId + ": " + description);
        context.appendLog(CombatLogEntry.now("link_queue", cardId, targetPlayerId + " <- " + description));
    }

    public int damageEnemy(BattleCoordinationContext context, String enemyId, int amount, String source, CardPlayResult result) {
        EnemyState enemy = context.requireEnemy(enemyId);
        enemy.takeDamage(amount);
        result.addDamage(amount);
        result.addEffect(enemyId + " takes " + amount + " damage");
        context.appendLog(CombatLogEntry.now("damage", source, enemyId + "-" + amount));
        return amount;
    }

    public int damageAllEnemies(BattleCoordinationContext context, List<String> enemyIds, int amount, String source, CardPlayResult result) {
        int total = 0;
        for (String enemyId : enemyIds) {
            total += damageEnemy(context, enemyId, amount, source, result);
        }
        return total;
    }

    public void applyVulnerableToAll(BattleCoordinationContext context, List<String> enemyIds, int layers, String source, CardPlayResult result) {
        for (String enemyId : enemyIds) {
            EnemyState enemy = context.requireEnemy(enemyId);
            enemy.applyVulnerable(layers);
            context.appendLog(CombatLogEntry.now("debuff", source, enemyId + " vulnerable +" + layers));
        }
        result.addEffect("all enemies gain " + layers + " vulnerable");
    }
}
