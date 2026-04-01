package com.ssetglow.spirelink.domain;

import java.util.List;

public record CardPlayContext(
        BattleCoordinationContext battleContext,
        String actorId,
        String primaryTargetId,
        List<String> enemyIds,
        String explicitTeammateTargetId,
        boolean upgraded
) {
}
