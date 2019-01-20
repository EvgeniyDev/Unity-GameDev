@echo off
set /p commit="Enter commit text: "

git checkout master
echo
git add *
echo
git commit -m "%commit%"
echo
git push --set-upstream origin master
echo

pause 