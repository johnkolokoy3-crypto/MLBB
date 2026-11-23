#!/usr/bin/env bash

set -euo pipefail

repository="johnkolokoy3-crypto/MLBB"
destination="${1:-MLBB}"

if [[ -d "$destination/.git" ]]; then
  echo "Repository already exists at: $destination"
  git -C "$destination" pull --ff-only
else
  git clone "https://github.com/${repository}.git" "$destination"
fi
