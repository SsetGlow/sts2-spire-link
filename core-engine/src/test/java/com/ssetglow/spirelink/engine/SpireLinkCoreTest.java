package com.ssetglow.spirelink.engine;

import com.ssetglow.spirelink.common.LinkEffectType;
import com.ssetglow.spirelink.common.TargetRule;
import com.ssetglow.spirelink.content.cards.CardRegistry;
import com.ssetglow.spirelink.content.events.EventRegistry;
import com.ssetglow.spirelink.content.relics.RelicRegistry;
import com.ssetglow.spirelink.domain.BattleCoordinationContext;
import com.ssetglow.spirelink.domain.ResonanceSpendRequest;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Random;

import static org.junit.jupiter.api.Assertions.*;

class SpireLinkCoreTest {
    @Test
    void shouldGainAndSpendResonance() {
        BattleCoordinationContext context = new BattleCoordinationContext(List.of("p1", "p2"));
        ResonanceManager manager = new ResonanceManager();
        assertEquals(3, manager.gain(context, 3, "card:overload_redirect"));
        assertTrue(manager.reaches(context, 3));
        assertEquals(2, manager.spend(context, new ResonanceSpendRequest("card:echo_circuit", 2, false)));
        assertEquals(1, context.resonanceState().current());
    }

    @Test
    void shouldResolveNextTeammateAndApplyLink() {
        BattleCoordinationContext context = new BattleCoordinationContext(List.of("p1", "p2", "p3"));
        TeamTargetResolver targetResolver = new TeamTargetResolver(new Random(1));
        String target = targetResolver.resolve(context, "p1", TargetRule.NEXT_TEAMMATE, null).playerId();
        assertEquals("p2", target);

        LinkResolver linkResolver = new LinkResolver();
        context.enqueueLink(linkResolver.createEffect("linked_guard", "p1", "p2", LinkEffectType.BLOCK, 5, TargetRule.NEXT_TEAMMATE, 1, "gain block next turn"));
        CombatTriggerDispatcher dispatcher = new CombatTriggerDispatcher(linkResolver);
        dispatcher.onTurnStart(context, "p2");
        assertEquals(5, context.requirePlayer("p2").block());
        assertEquals(1, context.linkTriggeredThisTurn());
    }

    @Test
    void shouldBootstrapAllContent() {
        assertEquals(8, CardRegistry.bootstrap().size());
        assertEquals(3, RelicRegistry.bootstrap().size());
        assertEquals(1, EventRegistry.bootstrap().size());
    }

    @Test
    void shouldProcessEventChoiceA() {
        BattleCoordinationContext context = new BattleCoordinationContext(List.of("p1", "p2"));
        EventChoiceProcessor processor = new EventChoiceProcessor(new ResonanceManager());
        processor.processAltarOfSyncChoice(context, "A");
        assertEquals(3, context.resonanceState().current());
        assertEquals("resonance_conductor", context.tempFlags().get("altar.rewardRelic"));
        assertFalse(context.tempFlags().containsKey("altar.doubleFirstLinkNextBattle"));
    }
}
