package com.ssetglow.spirelink.domain;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;

public record LinkEffect(
        String sourceCardId,
        String sourcePlayerId,
        String targetPlayerId,
        LinkEffectType effectType,
        int value,
        TargetRule targetRule,
        int expireTurn,
        String description
) {
}
