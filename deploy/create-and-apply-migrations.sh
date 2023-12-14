#!/bin/bash

if [ -z "$1" ]; then
  echo "WARNING: Migration name is missing."
  echo "Usage: $0 <migration-name>"
  exit 1
fi

cd ThereGame.Infrastructure

echo Creating migration \"$1\"...
dotnet ef -s ../ThereGame.Api/ migrations add $1 -o ./Data/Migrations

echo Updating DB...
dotnet ef database update

echo All migrations are applied
