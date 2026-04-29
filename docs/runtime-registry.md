# Runtime Registry / Lifecycle 说明

本轮新增：

- `SpireLinkRuntimeRegistry`
- `SpireLinkLifecycleCoordinator`
- `RegistrationSnapshot`
- `RegistrationSnapshotBuilder`

## 作用

这层的目标是把：

- provider
- registration bridge
- behavior spec
- preview
- runtime state

继续收敛成一个更接近真实 mod 初始化流程的结构。

## 当前能力

- 启动时可以重建 card / relic / event runtime registry
- 可以构建一份 registration snapshot
- 可以在 lifecycle coordinator 中拿到最近一次初始化快照
- 可以作为未来 BaseLib 真正注册时的中心协调点
