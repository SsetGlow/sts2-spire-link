#!/bin/bash
set -e
ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
DOTNET="dotnet"
if command -v godot4 > /dev/null 2>&1; then
  GODOT="godot4"
elif command -v godot > /dev/null 2>&1; then
  GODOT="godot"
else
  echo "Error: neither godot4 nor godot was found in PATH."
  exit 1
fi
BUILD_ROOT="$ROOT_DIR/build"
RELEASE_DIR="$BUILD_ROOT/SpireLink"
DLL_SOURCE="$ROOT_DIR/.godot/mono/temp/bin/Debug/SpireLink.dll"
PCK_SOURCE="$BUILD_ROOT/SpireLink.pck"
MANIFEST_PATH="$ROOT_DIR/SpireLink.json"
"$DOTNET" build "$ROOT_DIR/SpireLink.csproj" -c Debug
"$GODOT" --headless --path "$ROOT_DIR" --script "res://tools/build_pck.gd"
mkdir -p "$RELEASE_DIR"
rm -rf "$RELEASE_DIR"/*
cp "$DLL_SOURCE" "$RELEASE_DIR/SpireLink.dll"
cp "$PCK_SOURCE" "$RELEASE_DIR/SpireLink.pck"
cp "$MANIFEST_PATH" "$RELEASE_DIR/SpireLink.json"
VERSION=$(python3 - <<'PY'
import json
from pathlib import Path
print(json.loads(Path('SpireLink.json').read_text())['version'])
PY
)
ZIP_NAME="SpireLink-$VERSION.zip"
ZIP_STAGE_ROOT="$BUILD_ROOT/_zip_stage"
ZIP_MOD_FOLDER="$ZIP_STAGE_ROOT/SpireLink"
rm -rf "$ZIP_STAGE_ROOT"
mkdir -p "$ZIP_MOD_FOLDER"
cp -r "$RELEASE_DIR"/* "$ZIP_MOD_FOLDER/"
cd "$ZIP_STAGE_ROOT"
zip -qr "../$ZIP_NAME" "SpireLink"
