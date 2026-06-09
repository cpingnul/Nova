@echo off
chcp 65001 >nul
echo 正在清理 obj 和 bin 文件夹...
for /r %%i in (obj,bin) do (
    if exist "%%i" (
        echo 正在删除 %%i
        rd /s /q "%%i"
    )
)
echo 清理完成！
pause