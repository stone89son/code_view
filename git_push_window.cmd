@echo off
set /p msg=Type commit message: 
git add .
git commit -m "%msg%"
git push
pause