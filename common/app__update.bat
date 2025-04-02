DEL D:\apps\kaisha\kishu\koutei\*.exe
DEL D:\apps\kaisha\kishu\koutei\*.dll
DEL D:\apps\kaisha\kishu\koutei\Images\*.png
DEL D:\apps\kaisha\kishu\koutei\*.ico
DEL D:\apps\kaisha\kishu\koutei\Images\*.gif


COPY S:\tp\kaisha\kishu\koutei\*.exe				D:\apps\kaisha\kishu\koutei /V
IF ERRORLEVEL 1 GOTO ERR
COPY S:\tp\kaisha\kishu\koutei\*.dll				D:\apps\kaisha\kishu\koutei /V
IF ERRORLEVEL 1 GOTO ERR
COPY S:\tp\kaisha\kishu\koutei\Images\*.png				D:\apps\kaisha\kishu\koutei\Images /V
IF ERRORLEVEL 1 GOTO ERR
COPY S:\tp\kaisha\kishu\koutei\*.ico				D:\apps\kaisha\kishu\koutei /V
IF ERRORLEVEL 1 GOTO ERR
COPY S:\tp\kaisha\kishu\koutei\Images\*.gif				D:\apps\kaisha\kishu\koutei\Images /V
IF ERRORLEVEL 1 GOTO ERR

GOTO END

:ERR
ECHO ソフトウエア更新エラが発生しました！
ECHO エラ－コード %ERRORLEVEL%
ECHO このままシステム管理者に連絡してください
PAUSE

:END

D:
D:\apps\kaisha\kishu\koutei
START D:\apps\kaisha\kishu\koutei\koutei.exe
EXIT
