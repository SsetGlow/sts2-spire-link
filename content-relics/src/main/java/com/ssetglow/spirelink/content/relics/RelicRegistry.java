package com.ssetglow.spirelink.content.relics;

import com.ssetglow.spirelink.common.Rarity;

import java.util.LinkedHashMap;
import java.util.Map;

public final class RelicRegistry {
    private RelicRegistry() {
    }

    public static Map<String, RelicDefinition> bootstrap() {
        Map<String, RelicDefinition> relics = new LinkedHashMap<>();
        relics.put("resonance_conductor", new RelicDefinition("resonance_conductor", "共振导体", "Resonance Conductor", Rarity.COMMON,
                "每回合第一次你通过卡牌为队友提供正收益时，团队获得1点共鸣。"));
        relics.put("echo_prism", new RelicDefinition("echo_prism", "回声棱镜", "Echo Prism", Rarity.UNCOMMON,
                "每当你触发Link效果时，目标队友额外随机获得格挡/抽牌/攻击加成之一。"));
        relics.put("command_core", new RelicDefinition("command_core", "指挥核心", "Command Core", Rarity.RARE,
                "每回合第一次有玩家消耗共鸣值时，该玩家获4格挡，随机其他队友抽1；若消耗≥4，返还1点共鸣。"));
        return relics;
    }
}
