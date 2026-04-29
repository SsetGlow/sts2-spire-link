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

## 下一步

- 接真实 StS2 / BaseLib card lifecycle
- 把 support / link / resonance 状态绑定到具体游戏对象
- 把日志层升级成 debug overlay / mod logger
