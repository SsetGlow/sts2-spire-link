# BaseLib 注册接入现状

## 已完成

当前已经补到：

- 内容类具备更明确的 `LocalizationKey / Keywords / DesignRole`
- `BaseLibRegistrationFacade` 已作为集中注册入口落地
- `SpireLinkRegistrationBridge` 已开始向 `BaseLibRegistrationFacade` 汇流
- bootstrap 已进入 `RegisterIntoBaseLib()` 这条路径
- 已新增 `RegistrationPlan / RegistrationItem / BaseLibRegistrationSnapshot`
- 已能构建一份更明确的 **BaseLib 注册计划快照**
- 已新增 `IBaseLibRegistrationAdapter / BaseLibRegistrationExecutor / DryRunBaseLibRegistrationAdapter`
- 已能形成一条完整的 **plan -> adapter -> execution report** dry-run 链路
- 已新增 `ApiBindingPlan / ApiBindingProbe`，把最终真实 API 绑定目标也结构化收口
- 默认 bootstrap 现在走 `RegistrationExecutionMode.RealCandidate`，会调用 `CustomContentDictionary.AddModel(...)` / `AddEvent(...)` 注册内容
- dry-run 仍保留给 snapshot、诊断和无游戏运行时环境下的预览

## 还没完成

受限于当前本地缺少：
- StS2 实际运行时 DLL 验证环境
- dotnet / godot / 本地游戏安装

所以目前做的是：
- **把真实注册入口与结构全部铺好**
- **把注册序列压成可检查的 plan / snapshot / execution report**
- **把未来真实 BaseLib 绑定点也压成 binding plan / probe**
- **真实注册适配器已按当前 BaseLib 公开源码接入，但仍需要在装有 StS2 + BaseLib 的机器上做最终启动验证**

## 当前结论

现在已经从“纯骨架”推进到“注册入口 + 注册计划 + 快照 + 执行器 + 绑定规划都存在，只差最终 API 绑定验证”的阶段。
