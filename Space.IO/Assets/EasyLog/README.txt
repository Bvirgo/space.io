EASY LOG
========

Just 1 step to mute any log output in release
builds (editor is always debug). Compatible with Unity 
logging API, without change your code at all.

HOW TO:
- Drag&drop 'EasyLog' prefab to your first loaded scene.

Features:

* Automatic mute log in release builds.
* Mute by log level.
* Singletone persistent instance among scenes.
* Log level configuration per scene available.
* Compatible with Unity logging API.

Log level sorted by verbosity (muted to verbose):
NONE < EXCEPTION < ERROR < WARNING < ASSERT < LOG < ALL

Eeach log type in Unity is associated to one log level.
If the log type to log is less than log level, that output
will be muted:

LogType.Log --> LogLevel.LOG
LogType.Assert --> LogLevel.ASSERT
LogType.Warning --> LogLevel.WARGNING
LogType.Error --> LogLevel.ERROR
LogType.Exception --> LogLevel.EXCEPTION


