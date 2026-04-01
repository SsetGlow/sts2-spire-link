# Steam 创意工坊发布说明

## 已确认事实

- StS2 社区现有 Mod 普遍采用 **C# DLL + Godot `.pck` + manifest JSON**
- Steam 社区已存在 `app/2868840/workshop` 页面
- 社区公开项目的安装结构统一落在 `mods/<ModName>/` 目录

## 发布目录

```text
SpireLink/
  SpireLink.dll
  SpireLink.pck
  SpireLink.json
```

## 构建

```bash
./tools/build_release.sh
```

## 上传建议

使用以下任一方式上传：

- 游戏内 Workshop 上传入口（若官方提供）
- Steam 创意工坊网页上传页
- 官方后续提供的 Workshop Tool / SteamCMD 流程

上传包内容仅包含：

- `SpireLink.dll`
- `SpireLink.pck`
- `SpireLink.json`
