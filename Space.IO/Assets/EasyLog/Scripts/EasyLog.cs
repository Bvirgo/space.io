﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum LogLevel
{
	UNKNOWN,
	ALL,
	LOG,
	ASSERT,
	WARNING,
	ERROR,
	EXCEPTION,
	NONE,
}


public class EasyLog : MonoBehaviour, ILogHandler
{

	public static EasyLog Instance { get; private set; }


	public LogLevel LogLevelInDebug = LogLevel.ALL;
	public LogLevel LogLevelInRelease = LogLevel.NONE;
	public LogLevel LogLevelConfigured = LogLevel.UNKNOWN;


	public LogLevel CurrentLogLevel {

		get {

			LogLevel currentLogLevel = (_isDebug) 
				? LogLevelInDebug
				: LogLevelInRelease;

			if (LogLevel.UNKNOWN != LogLevelConfigured) {

				currentLogLevel = LogLevelConfigured;
			}

			return currentLogLevel;
		}
	}


	public bool IsLoggeable(LogType logType) {

		bool isLoggeable = ConvertLogTypeToLogLevel(logType) >= CurrentLogLevel;
		return isLoggeable;
	}


	public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
	{

		if (IsLoggeable(logType))
		{
			_defaultLogger.LogFormat(logType, context, format, args);
		}
	}

	public void LogException(Exception exception, UnityEngine.Object context)
	{
		if (IsLoggeable(LogType.Exception))
		{
			_defaultLogger.LogException(exception, context);
		}
	}


	static private EasyLog _instance;
	private ILogHandler _defaultLogger;

	private void Awake()
	{

		if (null == Instance)
		{
			Instance = this;
			_defaultLogger = Debug.unityLogger.logHandler;
			Debug.unityLogger.logHandler = this;
			transform.SetParent (null);
			DontDestroyOnLoad (gameObject);
		}
		else
		{
			Destroy(this);
		}

	}


	private void OnDestroy()
	{
		if (null != _defaultLogger)
		{
			Debug.unityLogger.logHandler = _defaultLogger;
		}
	}


	private bool _isDebug
	{
		get
		{
			return Debug.isDebugBuild;
		}
	}


	private LogLevel ConvertLogTypeToLogLevel(LogType logType) {

		LogLevel logLevel = LogLevel.UNKNOWN;

		switch (logType) {

		case LogType.Assert:

			logLevel = LogLevel.ASSERT;
			break;

		case LogType.Log:

			logLevel = LogLevel.LOG;
			break;

		case LogType.Warning:

			logLevel = LogLevel.WARNING;
			break;

		case LogType.Error:

			logLevel = LogLevel.ERROR;
			break;

		case LogType.Exception:

			logLevel = LogLevel.EXCEPTION;
			break;
		}

		return logLevel;
	}
}