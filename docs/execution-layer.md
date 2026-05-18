# 执行层说明

本轮新增执行层骨架，目标是把前面已经建好的：

- descriptor
- catalog
- behavior spec
- runtime battle state

真正串成一条“可执行路径”。

## 当前新增组件

- `ExecutionContext`
- `ConditionEvaluator`
- `TargetResolver`
- `RuntimeMutationService`
- `EffectExecutor`
- `CardBehaviorExecutor`
- `RelicBehaviorExecutor`
- `EventBehaviorExecutor`
- `SpireLinkSystemFacade`

## 当前能力

已经可以：
- 从 `SpireLinkBehaviorLibrary` 读取结构化效果定义
- 根据条件决定是否执行效果
- 将部分效果写入 `BattleCoordinationState`
- 产出运行日志
- 维护队伍顺序，并把 `next_teammate` 解析为实际玩家 ID
- 在队友回合开始时触发待处理 Link，并转换为支援动作记录
- 保留 `link_triggered_this_turn`，供 `Finale of Accord` 一类 payoff 判断

## 下一步

- 接真实 StS2 / BaseLib card lifecycle
- 把 support / link / resonance 状态绑定到具体游戏对象
- 把日志层升级成 debug overlay / mod logger

## 运行层调用顺序

当前规则层闭环应按这个顺序调用：

```csharp
SpireLinkRuntimeState.StartBattle("player_1", "player_2");
SpireLinkSystemFacade.Links.TriggerTurnStartLinks("player_1");
SpireLinkSystemFacade.Cards.Execute("LINKED_GUARD", "player_1", null, upgraded: false);
SpireLinkSystemFacade.Links.TriggerTurnStartLinks("player_2");
```

`TriggerTurnStartLinks` 负责推进该玩家回合、清空回合内计数、触发指向该玩家且未过期的 Link。卡牌执行本身不再推进回合，避免同一回合多次出牌导致 Link 提前过期。
