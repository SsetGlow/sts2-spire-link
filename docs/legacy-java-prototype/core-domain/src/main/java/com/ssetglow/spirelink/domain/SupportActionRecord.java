package com.ssetglow.spirelink.domain;

import com.ssetglow.spirelink.common.SupportActionType;

import java.time.Instant;

public record SupportActionRecord(
        String sourcePlayerId,
        String targetPlayerId,
        String sourceCardId,
        SupportActionType actionType,
        int value,
        Instant occurredAt
) {
    public static SupportActionRecord now(String sourcePlayerId, String targetPlayerId, String sourceCardId,
                                          SupportActionType actionType, int value) {
        return new SupportActionRecord(sourcePlayerId, targetPlayerId, sourceCardId, actionType, value, Instant.now());
    }
}
