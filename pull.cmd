@echo off

:: %ar - date (time ago)
:: %an - author name
:: %ae - email
:: %s - commit title
:: %b - commit body
:: %n - newLine

git log -5 --pretty=format:"%%ar by %%Cgreen(%%ae)%%Creset%%n   %%s %%n      %%b%%n"

git pull

PAUSE