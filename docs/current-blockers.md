# 当前阻塞与已处理问题

## 已解决

### 1. 技术路线误判
- 初期按 Java 原型搭了玩法和规则层。
- 通过外部调研已确认：StS2 社区当前主流是 **C# + Godot + BaseLib + Harmony**。
- 已完成仓库主技术栈迁移，旧 Java 内容已归档到 `docs/legacy-java-prototype/`。

### 2. 自动迁移脚本报错
- 之前 shell heredoc / quoting 方案多次失败。
- 已改为直接用 Python 在仓库内执行迁移，问题已解决。

## 当前仍存在的现实限制

### 1. 本机缺少 dotnet
当前无法在本机执行：
- `dotnet build`
- 生成最终 `SpireLink.dll`

### 2. 本机缺少 godot / godot4
当前无法在本机执行：
- Godot headless 导出
- 生成最终 `SpireLink.pck`

### 3. 本机没有检测到 Slay the Spire 2 安装目录
当前无法直接：
- 用本机游戏 DLL 做真实引用验证
- 自动拷贝到本地 `mods/` 目录测试

## 当前结论

在现有环境下，我已经把工程推进到：
- 技术栈正确
- 目录结构正确
- manifest 正确
- 打包脚本就绪
- Workshop 发布说明就绪

但 **还不能在这台机器上产出最终二进制成品**，除非补齐：
- Slay the Spire 2
- .NET SDK 9
- Godot 4.5.1 Mono
