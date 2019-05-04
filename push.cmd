@echo off
set /p commitMessage="Enter commit message: "
set /p commitBody="Print commit body: "

git checkout master
echo .
git add *
echo .
git commit -m "%commitMessage%" -m "%commitBody%"
echo .
git push --set-upstream origin master
echo .

pause 