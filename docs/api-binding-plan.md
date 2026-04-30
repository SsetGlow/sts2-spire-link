# API Binding Plan

## 目标

把未来需要真实对接的 BaseLib / StS2 API 接口面整理清楚，避免后续到真实环境后再重新拆架构。

## 当前已识别绑定域

### Cards
- custom card registration
- card execution hook

### Relics
- custom relic registration
- relic trigger hook

### Events
- custom event registration
- event option resolution hook

### Lifecycle
- combat start hook
- turn start hook
- combat end hook

## 当前状态
- 已形成 `ApiBindingPlan`
- 已形成 `ApiBindingProbeResult`
- 已被纳入 registration snapshot
