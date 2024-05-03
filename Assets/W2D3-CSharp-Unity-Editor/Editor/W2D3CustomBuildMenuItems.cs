using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEditor;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace W2D3.CSharp.Unity.Editor
{
	public static class W2D3CustomBuildMenuItems
	{
		[MenuItem("Build/Windows x64")]
		static void MyBuildAndPlay()
		{
			var now = DateTime.Now;
			var isWeekend = now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;

			// Uncomment this to force it to be weekend
			//isWeekend = true;

			if (isWeekend)
			{
				var answeredBuildAnyway = EditorUtility.DisplayDialog("It's Weekend",
					"Dear employee, we're not paying overtime in weekends!",
					ok: "Build Anyway",
					cancel: "Cancel and enjoy life");

				if (!answeredBuildAnyway)
				{
					EditorUtility.DisplayDialog("Excellent choice", "Excellent choice", "Yes");
					EditorApplication.Exit(0);  // 0 is the return code, 0 = no errors
					return;
				}
			}

			// EditorBuildSettings.scenes contains all the scenes in the Build Settings (Ctrl+Shift+B),
			// but we may want to include a specific one
			string[] scenes = { "Assets/W2D3-CSharp-Unity-Editor/W2D3UnityEditorSceneToBuild.unity" };
			var buildPlayerOptions = new BuildPlayerOptions
			{
				scenes = scenes,
				locationPathName = "Builds/mygame.exe",
				target = BuildTarget.StandaloneWindows64
			};

			var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
			Debug.Log(report.summary.result);

			// Open the folder where we've built the app
			EditorUtility.RevealInFinder(buildPlayerOptions.locationPathName);
		}
	}
}
