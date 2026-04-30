# Registration Adapter 说明

## 当前目标

为未来真实 BaseLib API 调用预留一层稳定边界：

- `IBaseLibRegistrationAdapter`
- `BaseLibRegistrationExecutor`
- `DryRunBaseLibRegistrationAdapter`

## 当前能力

目前可以：
- 根据 `RegistrationPlan` 顺序执行 card / relic / event 注册动作
- 通过 dry-run adapter 输出注册步骤
- 生成 `RegistrationExecutionReport`

## 未来替换方式

后续只需要新增一个真正的 BaseLib adapter，例如：
- `RealBaseLibRegistrationAdapter`

然后把它注入：
- `SpireLinkRegistrationBridge.RegisterIntoBaseLib(adapter)`

即可把现在的 dry-run 链路替换成真实注册调用。
