package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.CardType;
import com.ssetglow.spirelink.common.Keyword;
import com.ssetglow.spirelink.common.Rarity;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Set;

public final class CardRegistry {
    private CardRegistry() {
    }

    public static Map<String, CardDefinition> bootstrap() {
        Map<String, CardDefinition> cards = new LinkedHashMap<>();
        cards.put("linked_guard", new CardDefinition("linked_guard", "协同护幕", "Linked Guard", 1, CardType.SKILL, Rarity.COMMON,
                Set.of(Keyword.LINK), "获得7格挡；下一位队友下回合开始时获得5格挡；获得1点共鸣。", "自身9格挡；队友7格挡。"));
        cards.put("target_mark", new CardDefinition("target_mark", "弱点标定", "Target Mark", 1, CardType.SKILL, Rarity.COMMON,
                Set.of(Keyword.LINK), "使所有敌人获得1层易伤；下一位队友本回合第一张攻击额外造成4伤害；获得1点共鸣。", "易伤改2层；追加伤害6。"));
        cards.put("resonance_prep", new CardDefinition("resonance_prep", "共振整备", "Resonance Prep", 0, CardType.SKILL, Rarity.COMMON,
                Set.of(Keyword.LINK), "抽1；下一位队友下回合第一张牌费用-1；若成功作用获得1点共鸣。", "改为抽2。"));
        cards.put("echo_circuit", new CardDefinition("echo_circuit", "回响回路", "Echo Circuit", 1, CardType.SKILL, Rarity.UNCOMMON,
                Set.of(Keyword.RESONATE), "获得8格挡；若团队共鸣≥3，额外抽2。可选消耗3点共鸣，使指定队友抽1。", "格挡10。"));
        cards.put("resonant_strike", new CardDefinition("resonant_strike", "共鸣冲击", "Resonant Strike", 2, CardType.ATTACK, Rarity.UNCOMMON,
                Set.of(Keyword.RESONATE), "造成14伤害；可额外消耗最多3点共鸣，每点追加5伤害。", "基础18；每点追加6。"));
        cards.put("chain_repair", new CardDefinition("chain_repair", "连锁修复", "Chain Repair", 1, CardType.SKILL, Rarity.UNCOMMON,
                Set.of(Keyword.LINK, Keyword.GUARD_LINK), "选择队友：清1个负面状态；若无法清除则获得8格挡；成功帮助后获得2点共鸣。", "格挡11；清除成功则目标额外抽1。"));
        cards.put("overload_redirect", new CardDefinition("overload_redirect", "过载分流", "Overload Redirect", 1, CardType.SKILL, Rarity.RARE,
                Set.of(Keyword.LINK, Keyword.RESONATE), "失去3生命，获得3点共鸣；下一位队友下回合开始时抽2；若共鸣达到5+，获得1能量。", "失去生命改为2。"));
        cards.put("finale_of_accord", new CardDefinition("finale_of_accord", "协同终曲", "Finale of Accord", 3, CardType.ATTACK, Rarity.RARE,
                Set.of(Keyword.RESONATE), "对所有敌人造成16伤害；若本回合前已有至少2次Link触发，额外消耗5点共鸣再造成12 AoE并全队获5格挡。", "20 / 15 AoE，全队6格挡。"));
        return cards;
    }
}
