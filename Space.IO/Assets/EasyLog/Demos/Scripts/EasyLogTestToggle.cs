using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EasyLogTestToggle : MonoBehaviour {

	public void OnLogLevelMarkerChanged(bool value) {

		if (value) {

			LogLevel logLevel = (LogLevel)Enum.Parse (typeof(LogLevel), gameObject.name);
			EasyLog.Instance.LogLevelConfigured = logLevel;
		}
	}
}
