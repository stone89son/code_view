#!/bin/bash
read -p "Nhập commit message: " msg
git add .
git commit -m "$msg"
git push