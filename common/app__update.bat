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
ECHO �\�t�g�E�G�A�X�V�G�����������܂����I
ECHO �G���|�R�[�h %ERRORLEVEL%
ECHO ���̂܂܃V�X�e���Ǘ��҂ɘA�����Ă�������
PAUSE

:END

D:
D:\apps\kaisha\kishu\koutei
START D:\apps\kaisha\kishu\koutei\koutei.exe
EXIT
