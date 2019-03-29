using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class EasyLogTestMain : MonoBehaviour {


	public Text TxtOutput;
	public Dropdown DropLogType;

	public void Log() {


		StringBuilder output = new StringBuilder ();

		output.AppendLine (string.Format("{0}", DateTime.Now));


		LogType logType =  (LogType) Enum.Parse(typeof(LogType), DropLogType.captionText.text);

		output.AppendLine (string.Format ("logType: {0} | logLevel: {1}", logType, EasyLog.Instance.CurrentLogLevel));


		if (EasyLog.Instance.IsLoggeable(logType)) {

			output.AppendLine ("Should have been logged");
		} else {

			output.AppendLine ("Shouldn't have been logged");
		}


		string message = string.Empty;
		switch (logType) {

		case LogType.Log:

			message = "Log message";
			Debug.Log (message);	
			break;

		case LogType.Warning:

			message = "Warning message";
			Debug.LogWarning (message);	
			break;

		case LogType.Error:

			message = "Error message";
			Debug.LogError (message);	
			break;

		case LogType.Assert:

			message = "Assertinon message";
			Debug.Assert (false, message);
			break;

		case LogType.Exception:

			message = "Exception message";
			Debug.LogException (new Exception ());
			break;

		}

		output.AppendLine(string.Format("Message: {0}", message));
		TxtOutput.text = output.ToString ();
	}
}
