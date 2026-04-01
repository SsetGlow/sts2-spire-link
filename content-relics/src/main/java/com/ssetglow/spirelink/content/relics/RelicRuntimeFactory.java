package com.ssetglow.spirelink.content.relics;

import com.ssetglow.spirelink.engine.RelicRuntime;
import com.ssetglow.spirelink.engine.SpireLinkRelic;

import java.util.ArrayList;
import java.util.List;

public final class RelicRuntimeFactory {
    private RelicRuntimeFactory() {
    }

    public static RelicRuntime createDefault() {
        List<SpireLinkRelic> relics = new ArrayList<>();
        relics.add(new ResonanceConductorRelic());
        relics.add(new EchoPrismRelic());
        relics.add(new CommandCoreRelic());
        return new RelicRuntime(relics);
    }
}
