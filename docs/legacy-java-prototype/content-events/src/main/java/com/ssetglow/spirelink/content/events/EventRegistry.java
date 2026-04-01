package com.ssetglow.spirelink.content.events;

import java.util.List;
import java.util.Map;

public final class EventRegistry {
    private EventRegistry() {
    }

    public static Map<String, EventDefinition> bootstrap() {
        return Map.of(
                "altar_of_sync",
                new EventDefinition(
                        "altar_of_sync",
                        "同步祭坛",
                        "Altar of Sync",
                        "若你们愿意共享节奏，力量将不再属于个人。",
                        List.of(
                                new EventChoice("A", "建立共鸣", "全队获得3点共鸣，随机一名玩家获得共振导体，接下来2场战斗敌人开局+1力量。"),
                                new EventChoice("B", "强制同步", "下一场战斗首次Link额外触发一次，但每人洗入1张负担牌。"),
                                new EventChoice("C", "拒绝共鸣", "无事发生，全队回复5点生命。")
                        )
                )
        );
    }
}
