# BaseLib 注册接入现状

## 已完成

当前已经补到：

- 内容类具备更明确的 `LocalizationKey / Keywords / DesignRole`
- `BaseLibRegistrationFacade` 已作为集中注册入口落地
- `SpireLinkRegistrationBridge` 已开始向 `BaseLibRegistrationFacade` 汇流
- bootstrap 已进入 `RegisterIntoBaseLib()` 这条路径
- 已新增 `RegistrationPlan / RegistrationItem / BaseLibRegistrationSnapshot`
- 已能构建一份更明确的 **BaseLib 注册计划快照**

## 还没完成

受限于当前本地缺少：
- StS2 实际运行时 DLL 验证环境
- dotnet / godot / 本地游戏安装

所以目前做的是：
- **把真实注册入口与结构全部铺好**
- **把注册序列压成可检查的 plan / snapshot**
- **但还没验证最终的 BaseLib 实际 API 调用细节**

## 当前结论

现在已经从“纯骨架”推进到“注册入口 + 注册计划 + 快照都存在，只差最终 API 绑定验证”的阶段。
