package com.ssetglow.spirelink.domain;

import java.time.Instant;

public record CombatLogEntry(Instant occurredAt, String type, String source, String detail) {
    public static CombatLogEntry now(String type, String source, String detail) {
        return new CombatLogEntry(Instant.now(), type, source, detail);
    }
}
