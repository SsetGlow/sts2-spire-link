package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.engine.GameActionExecutor;
import com.ssetglow.spirelink.engine.RelicRuntime;
import com.ssetglow.spirelink.engine.SpireLinkCard;
import com.ssetglow.spirelink.domain.CardPlayContext;
import com.ssetglow.spirelink.domain.CardPlayResult;

public abstract class AbstractSpireLinkCard implements SpireLinkCard {
    @Override
    public CardPlayResult play(CardPlayContext context, GameActionExecutor executor, RelicRuntime relicRuntime) {
        CardPlayResult result = new CardPlayResult(id(), context.actorId());
        doPlay(context, executor, relicRuntime, result);
        return result;
    }

    protected abstract void doPlay(CardPlayContext context, GameActionExecutor executor,
                                   RelicRuntime relicRuntime, CardPlayResult result);
}
