package com.ssetglow.spirelink.common;

import java.util.List;
import java.util.Objects;

public final class TeamOrderUtils {
    private TeamOrderUtils() {
    }

    public static String nextTeammate(List<String> teamOrder, String actorId) {
        Objects.requireNonNull(teamOrder, "teamOrder");
        Objects.requireNonNull(actorId, "actorId");
        if (teamOrder.size() < 2) {
            throw new IllegalArgumentException("At least two players are required.");
        }
        int index = teamOrder.indexOf(actorId);
        if (index < 0) {
            throw new IllegalArgumentException("Actor not found in team order: " + actorId);
        }
        return teamOrder.get((index + 1) % teamOrder.size());
    }
}
