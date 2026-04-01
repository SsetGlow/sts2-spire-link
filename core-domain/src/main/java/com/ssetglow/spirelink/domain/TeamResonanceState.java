package com.ssetglow.spirelink.domain;

import com.ssetglow.spirelink.common.ResonanceConstants;

import java.time.Instant;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class TeamResonanceState {
    private int current;
    private final int max;
    private final List<ResonanceHistory> history;

    public TeamResonanceState() {
        this(ResonanceConstants.DEFAULT_MAX);
    }

    public TeamResonanceState(int max) {
        this.current = ResonanceConstants.DEFAULT_MIN;
        this.max = max;
        this.history = new ArrayList<>();
    }

    public int gain(int value, String source) {
        int before = current;
        current = Math.min(max, current + Math.max(0, value));
        record(source, current - before);
        return current - before;
    }

    public int spend(int value, String source) {
        if (value < 0) {
            throw new IllegalArgumentException("Spend value must be >= 0");
        }
        int actual = Math.min(current, value);
        current -= actual;
        record(source, -actual);
        return actual;
    }

    public boolean canSpend(int value) {
        return value >= 0 && current >= value;
    }

    public boolean reach(int threshold) {
        return current >= threshold;
    }

    public int current() {
        return current;
    }

    public int max() {
        return max;
    }

    public List<ResonanceHistory> history() {
        return Collections.unmodifiableList(history);
    }

    private void record(String source, int delta) {
        history.add(new ResonanceHistory(Instant.now(), source, delta, current));
    }
}
