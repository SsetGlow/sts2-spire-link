# Spire Link（尖塔共鸣）

一个面向《Slay the Spire 2》联机合作模式的协同机制 Mod 原型工程。

## 当前实现范围

本仓库当前提供：

- 多模块 Java 工程骨架
- 共鸣值领域模型与历史记录
- Link / Resonate 的抽象规则引擎
- 首批卡牌 / 遗物 / 事件定义注册
- 8 张卡的原型行为实现
- 3 个遗物的运行时监听实现
- 战斗模拟编排服务与战斗日志
- UI Overlay 数据模型
- 基础单元测试

> 注意：当前阶段按“领域模型 + 规则引擎 + 事件总线”抽象实现，尚未绑定具体 StS2 Mod API。

## 模块说明

- `core-common`：常量、枚举、公共模型
- `core-domain`：领域对象与战斗上下文
- `core-engine`：规则引擎、运行时接口、战斗编排
- `content-cards`：卡牌定义、注册表、卡牌行为原型
- `content-relics`：遗物定义、注册表、遗物监听原型
- `content-events`：事件定义与注册表
- `ui-overlay`：UI 展示状态模型

## 后续接入建议

1. 增加 `adapter-sts2` 模块，对接实际 Mod Hook/API
2. 将卡牌/遗物/事件定义映射到游戏对象
3. 把 `CombatTriggerDispatcher` 接到真实战斗生命周期
4. 用 `BattleCoordinationContext` 作为联机战斗共享态根对象

## 本地构建

```bash
./gradlew test
```

如果本机没有 Gradle Wrapper，可先安装 Gradle 8.7+ 后执行：

```bash
gradle test
```
