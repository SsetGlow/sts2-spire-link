#!/bin/bash
set -e
ROOT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
RELEASE_ROOT="$ROOT_DIR/release"
OUT_ROOT="$ROOT_DIR/build/player-package"
PACKAGE_ROOT="$OUT_ROOT/SpireLink"

mkdir -p "$PACKAGE_ROOT"
rm -rf "$PACKAGE_ROOT"/*

cp "$ROOT_DIR/SpireLink.json" "$PACKAGE_ROOT/SpireLink.json"
cp "$RELEASE_ROOT/SpireLink/README.txt" "$PACKAGE_ROOT/README.txt"

if [ -f "$ROOT_DIR/build/SpireLink/SpireLink.dll" ]; then
  cp "$ROOT_DIR/build/SpireLink/SpireLink.dll" "$PACKAGE_ROOT/SpireLink.dll"
fi
if [ -f "$ROOT_DIR/build/SpireLink/SpireLink.pck" ]; then
  cp "$ROOT_DIR/build/SpireLink/SpireLink.pck" "$PACKAGE_ROOT/SpireLink.pck"
fi

cat <<EOF
Player package assembled at:
$PACKAGE_ROOT

Expected final player package files:
- SpireLink.dll
- SpireLink.pck
- SpireLink.json
- README.txt
EOF
