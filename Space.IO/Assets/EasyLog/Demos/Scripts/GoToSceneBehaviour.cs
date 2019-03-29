﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneBehaviour : MonoBehaviour {


	public void GoToScene(string scene) {

		SceneManager.LoadScene (scene);
	}
}