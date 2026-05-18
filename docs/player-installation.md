# 玩家安装说明

## 最终正确的玩家交付形态

玩家拿到的应该是一个压缩包，解压后类似：

```text
SpireLink.zip
  ├── SpireLink/
  │   ├── SpireLink.dll
  │   ├── SpireLink.pck
  │   └── SpireLink.json
  └── README.txt
```

如果玩家尚未安装 BaseLib，则还应额外提供：

```text
BaseLib/
  ├── BaseLib.dll
  ├── BaseLib.pck
  └── BaseLib.json
```

## 玩家安装步骤

### Windows / Linux
将 `SpireLink/` 文件夹复制到：

```text
<Slay the Spire 2>/mods/
```

### macOS
将 `SpireLink/` 文件夹复制到：

```text
<Slay the Spire 2>/SlayTheSpire2.app/Contents/MacOS/mods/
```

BaseLib 也必须存在于同一个 `mods/` 目录下：

```text
mods/
  BaseLib/
    BaseLib.dll
    BaseLib.pck
    BaseLib.json
  SpireLink/
    SpireLink.dll
    SpireLink.pck
    SpireLink.json
```

首次启动带 mod 的游戏时，确认游戏弹出的 modded mode 提示；之后可在 Settings -> Mod Settings 里确认 `SpireLink` 已加载。

## 作者本地构建步骤

需要先安装：

- Slay the Spire 2
- .NET SDK 9
- Godot/MegaDot 4.5.1 Mono
- BaseLib，放入游戏 `mods/BaseLib/`

然后在仓库根目录执行：

```bash
./tools/build_release.sh
```

如果游戏或 Godot 不在默认位置，用 MSBuild 属性覆盖路径：

```bash
dotnet publish SpireLink.csproj -c Release \
  -p:SteamLibraryPath="/path/to/Steam/steamapps" \
  -p:GodotPath="/path/to/Godot"
```

## 玩家不应该做的事

- 不应该自己编译
- 不应该自己执行 dotnet/godot 命令
- 不应该自己拼接 dll/pck/json

## 当前项目状态

当前仓库已经加入了 `release/` 目录模板，用来约束最终玩家包目录结构。
