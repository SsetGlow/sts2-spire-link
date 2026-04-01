# 发布前检查清单

## 工程
- [ ] `SpireLink.csproj` 能在目标环境 `dotnet build`
- [ ] `project.godot` 可被 Godot 4.5.1 Mono 正常打开
- [ ] `tools/build_release.sh` 能生成 `.dll/.pck/.json`

## 内容
- [ ] 8 张卡均已接入实际内容注册
- [ ] 3 个遗物均已接入实际内容注册
- [ ] `Altar of Sync` 事件已接入实际事件系统
- [ ] 英文文案完整
- [ ] 中文文案完整
- [ ] 卡图 / relic 图已替换占位图

## 测试
- [ ] 单人启动不报错
- [ ] 联机房间启动不报错
- [ ] 多人战斗中 mod 正常加载
- [ ] BaseLib 依赖可自动识别

## 发布
- [ ] `build/SpireLink/` 下有完整发布目录
- [ ] `build/SpireLink-<version>.zip` 可解压后直接放入 `mods/`
- [ ] Workshop 页面素材准备完成
