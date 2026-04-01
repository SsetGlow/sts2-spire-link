package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;

public interface SpireLinkCard {
    String id();
    CardPlayResult play(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime);
}
