# Spire Link 内容落地计划

## 卡牌（第一版）
1. Linked Guard
2. Target Mark
3. Resonance Prep
4. Echo Circuit
5. Resonant Strike
6. Chain Repair
7. Overload Redirect
8. Finale of Accord

## 遗物（第一版）
1. Resonance Conductor
2. Echo Prism
3. Command Core

## 事件（第一版）
1. Altar of Sync

## 下一步编码重点
- 用 BaseLib 的实际内容注册方式替换当前“类型触发式注册”骨架
- 将卡牌数值和行为从文案定义提升为真实 `CardModel` 行为实现
- 把 team resonance 状态接到战斗生命周期 patch
- 增加联机 UI / tooltip 展示
