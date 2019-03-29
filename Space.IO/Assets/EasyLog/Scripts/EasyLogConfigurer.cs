using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLogConfigurer : MonoBehaviour {



	public bool SetValueOnStart = true;
	public bool RestoreValueOnDestroy = true;
	public LogLevel LogLevelValue = LogLevel.UNKNOWN;


	public void SetLogLevel(LogLevel logLevel) {

		EasyLog.Instance.LogLevelConfigured = logLevel;
	}


	private LogLevel _logLevelValuePrevious;

	private void Start() {

		if (SetValueOnStart) {

			_logLevelValuePrevious = EasyLog.Instance.CurrentLogLevel;
			SetLogLevel (LogLevelValue);
		}
	}


	private void OnDestroy() {

		if (RestoreValueOnDestroy) {

			SetLogLevel(_logLevelValuePrevious);
		}
	}
}
