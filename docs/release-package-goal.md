# Release Package Goal

## 目标

最终不是交付源码仓库，而是交付一个玩家可直接解压使用的包。

## 目标压缩包结构

```text
SpireLink.zip
  └── SpireLink/
      ├── SpireLink.dll
      ├── SpireLink.pck
      ├── SpireLink.json
      └── README.txt
```

## 当前约束

在真正二进制产物可生成前，仓库先维护：
- `release/SpireLink/` 模板目录
- `release/BaseLib/` 依赖说明目录
- `release/release-manifest.json`

这样等本地构建条件齐备后，可以直接把生成物复制进 `release/SpireLink/`，然后打成最终玩家包。
