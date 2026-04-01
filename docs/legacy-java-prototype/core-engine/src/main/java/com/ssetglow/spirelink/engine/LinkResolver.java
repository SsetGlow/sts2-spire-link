package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.SupportActionType;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.LinkEffect;
import com.ssetglow.spirelink.domain.PlayerState;
import com.ssetglow.spirelink.domain.SupportActionRecord;

import java.util.ArrayList;
import java.util.List;

public class LinkResolver {
    public List<SupportActionRecord> triggerTurnStartLinks(BattleCoordinationContext context, String playerId, int currentTurn) {
        List<LinkEffect> toApply = new ArrayList<>();
        context.pendingLinks().removeIf(effect -> {
            boolean match = playerId.equals(effect.targetPlayerId()) && effect.expireTurn() >= currentTurn;
            if (match) {
                toApply.add(effect);
            }
            return match;
        });

        List<SupportActionRecord> records = new ArrayList<>();
        for (LinkEffect effect : toApply) {
            PlayerState target = context.requirePlayer(playerId);
            switch (effect.effectType()) {
                case BLOCK -> {
                    target.gainBlock(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.GRANT_BLOCK, effect.value()));
                }
                case DRAW -> {
                    target.queueDraw(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.GRANT_DRAW, effect.value()));
                }
                case COST_REDUCTION -> {
                    target.reduceNextCardCost(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.REDUCE_COST, effect.value()));
                }
                case ATTACK_BONUS -> {
                    target.addAttackBonus(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.GRANT_ATTACK_BONUS, effect.value()));
                }
                case CLEANSE -> {
                    target.cleanseDebuff(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.CLEANSE_DEBUFF, effect.value()));
                }
                case TEAM_BLOCK, CUSTOM -> {
                    target.gainBlock(effect.value());
                    records.add(SupportActionRecord.now(effect.sourcePlayerId(), playerId, effect.sourceCardId(), SupportActionType.PROTECT, effect.value()));
                }
            }
            context.recordSupport(records.get(records.size() - 1));
            context.incrementLinkTriggeredThisTurn();
        }
        return records;
    }

    public LinkEffect createEffect(String cardId, String sourcePlayerId, String targetPlayerId,
                                   LinkEffectType type, int value, com.ssetglow.spirelink.common.TargetRule targetRule,
                                   int expireTurn, String description) {
        return new LinkEffect(cardId, sourcePlayerId, targetPlayerId, type, value, targetRule, expireTurn, description);
    }
}
