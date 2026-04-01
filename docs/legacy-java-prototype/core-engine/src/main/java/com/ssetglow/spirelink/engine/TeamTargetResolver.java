package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.common.TeamOrderUtils;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;

import java.util.Comparator;
import java.util.List;
import java.util.Objects;
import java.util.Random;
import java.util.stream.Collectors;

public class TeamTargetResolver {
    private final Random random;

    public TeamTargetResolver() {
        this(new Random());
    }

    public TeamTargetResolver(Random random) {
        this.random = random;
    }

    public ResolvedTarget resolve(BattleCoordinationContext context, String sourcePlayerId,
                                  TargetRule rule, String explicitTargetId) {
        Objects.requireNonNull(context);
        return switch (rule) {
            case NEXT_TEAMMATE -> new ResolvedTarget(
                    TeamOrderUtils.nextTeammate(context.teamOrder(), sourcePlayerId),
                    "next teammate by turn order"
            );
            case RANDOM_TEAMMATE -> {
                List<String> candidates = teammates(context, sourcePlayerId);
                yield new ResolvedTarget(candidates.get(random.nextInt(candidates.size())), "random teammate");
            }
            case LOWEST_HP_TEAMMATE -> {
                String target = teammates(context, sourcePlayerId).stream()
                        .min(Comparator.comparingInt(id -> context.requirePlayer(id).hp()))
                        .orElseThrow();
                yield new ResolvedTarget(target, "lowest hp teammate");
            }
            case EXPLICIT_TEAMMATE -> new ResolvedTarget(explicitTargetId, "explicit target");
            case SELF -> new ResolvedTarget(sourcePlayerId, "self");
            case ALL_TEAMMATES -> new ResolvedTarget("*", "all teammates");
        };
    }

    private List<String> teammates(BattleCoordinationContext context, String sourcePlayerId) {
        return context.teamOrder().stream()
                .filter(id -> !id.equals(sourcePlayerId))
                .collect(Collectors.toList());
    }
}
