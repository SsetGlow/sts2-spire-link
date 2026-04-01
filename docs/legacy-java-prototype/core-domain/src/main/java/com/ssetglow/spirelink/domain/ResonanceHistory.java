package com.ssetglow.spirelink.domain;

import java.time.Instant;

public record ResonanceHistory(Instant occurredAt, String source, int delta, int afterValue) {
}
