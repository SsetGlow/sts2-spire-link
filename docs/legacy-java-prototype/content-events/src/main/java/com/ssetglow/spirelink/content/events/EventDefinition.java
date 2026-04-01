package com.ssetglow.spirelink.content.events;

import java.util.List;

public record EventDefinition(String id, String nameZh, String nameEn, String description, List<EventChoice> choices) {
}
