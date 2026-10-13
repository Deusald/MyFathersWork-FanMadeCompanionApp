#!/usr/bin/env bash
set -e

# Ensure dotnet is on PATH
export DOTNET_ROOT="${DOTNET_ROOT:-$HOME/.dotnet}"
export PATH="$HOME/.dotnet:$HOME/.local/bin:$PATH"

REPO_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
APP_DIR="$REPO_DIR/MyFathersWorkWebApp/MyFathersWorkWebApp"

echo "=== Starting My Father's Work Web Companion App ==="
echo "URL: http://localhost:5000"
echo "Press Ctrl+C to stop."
echo ""

cd "$APP_DIR"
exec dotnet run --urls "http://localhost:5000" "$@"
