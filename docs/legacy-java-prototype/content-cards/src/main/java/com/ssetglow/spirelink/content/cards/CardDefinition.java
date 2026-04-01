package com.ssetglow.spirelink.content.cards;

import com.ssetglow.spirelink.common.CardType;
import com.ssetglow.spirelink.common.Keyword;
import com.ssetglow.spirelink.common.Rarity;

import java.util.Set;

public record CardDefinition(
        String id,
        String nameZh,
        String nameEn,
        int cost,
        CardType type,
        Rarity rarity,
        Set<Keyword> keywords,
        String effectText,
        String upgradeText
) {
}
