# Spire Link（尖塔共鸣）

这是一个面向 **Slay the Spire 2** 的联机协同机制 Mod，围绕以下核心机制设计：

- **Resonance（共鸣值）**：团队共享资源池
- **Link**：把当前玩家的出牌收益延迟传递给下一位队友
- **Resonate**：基于共鸣阈值或主动消耗触发强化收益

## 已确认的真实技术路线

根据社区现有公开项目与模板，本项目当前采用：

- **C# / .NET 9**
- **Godot.NET.Sdk 4.5.1**
- **BaseLib-StS2** 作为内容扩展基座
- **Harmony** 作为运行时补丁机制
- Mod 安装目录：
  - Windows / Linux：`<Slay the Spire 2>/mods/SpireLink/`
  - macOS：`<Slay the Spire 2>/SlayTheSpire2.app/Contents/MacOS/mods/SpireLink/`

## 当前工程包含

- StS2 社区模板兼容的 `SpireLink.csproj`
- Mod manifest：`SpireLink.json`
- Godot 项目：`project.godot`
- 导出配置：`export_presets.cfg`
- 构建打包脚本：`tools/build_release.sh`
- 创意工坊发布说明：`docs/workshop-publishing.md`
- Workshop 页面文案草稿：`docs/workshop-copywriting.md`
- 发布检查清单：`docs/release-checklist.md`
- 中英双语本地化目录：`SpireLink/localization/eng`、`SpireLink/localization/zh_cn`
- 卡牌 / 遗物 / 事件目录清单：`SpireLink/content/**/catalog.json`
- Spire Link 的卡牌 / 遗物 / 事件 / 本地化 / 机制代码骨架
- 旧 Java 机制原型已归档到：`docs/legacy-java-prototype/`

## 构建前提

需要本机安装：

1. **Slay the Spire 2**
2. **Godot / MegaDot 4.5.1 Mono**
3. **.NET SDK 9**

## 打包命令

```bash
./tools/build_release.sh
```

## 参考依据

- `Alchyr/BaseLib-StS2`
- `Alchyr/ModTemplate-StS2`
- `jdr1813/BetterSpire2`
- `Rain156/sts2-RMP-Mods`
