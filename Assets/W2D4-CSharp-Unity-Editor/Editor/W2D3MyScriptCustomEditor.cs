using UnityEditor;
using UnityEngine;

namespace W2D3.CSharp.Unity.Editor
{
	/// <summary>
	/// Adds a "Add 1" button in the inspector for any W2D3MyScript, which adds 1 to its myProperty
	/// Adds a "Clone me" button to create a clone above "myProperty" meters above it
	/// </summary>
	[CustomEditor(typeof(W2D3MyScript))]
	public class W2D3MyScriptCustomEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Add 1"))
				OnAdd1Clicked();

			if (GUILayout.Button("Clone me"))
				OnCloneMeClicked();
		}

		void OnAdd1Clicked()
		{
			var obj = (W2D3MyScript)target;
			// Registering undo for adding 1, so that we can Ctrl+Z it, if needed
			Undo.RecordObject(obj, "Add 1 to myProperty");
			obj.myProperty += 1;
		}

		void OnCloneMeClicked()
		{
			var obj = (W2D3MyScript)target;
			var clone = Instantiate(obj.gameObject);

			// Move by <obj.myProperty> meters above the object
			var clonePos = obj.transform.position + Vector3.up * obj.myProperty;
			clone.transform.position = clonePos;

			// Optionally change the name of the clone
			clone.name = obj.name + " Clone";

			// Registering undo for the clone creation, so that we can Ctrl+Z it, if needed
			Undo.RegisterCreatedObjectUndo(clone, "Clone Object");

			// Select the clone automatically, so we can just keep cloning by clicking!
			Selection.activeGameObject = clone;

			// Move the Scene camera (not the Game camera) to the newly created clone
			// There can be multiple Scene Views, since you can open any number of SceneView tabs, but
			// we're just taking the first one, for simplicity
			var firstSceneView = SceneView.sceneViews[0] as SceneView;
			firstSceneView.LookAt(clonePos);
		}
	}
}
