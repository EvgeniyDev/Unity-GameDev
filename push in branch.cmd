set /p commit="Enter commit text: "

git checkout master
git add *
git commit -m "%commit%"
git push --set-upstream origin master

pause 