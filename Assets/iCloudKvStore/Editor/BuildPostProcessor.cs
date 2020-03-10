#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public class BuildPostProcessor
{
	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string buildPath)
	{
		string pbxPath = PBXProject.GetPBXProjectPath(buildPath);
		var capManager = new ProjectCapabilityManager(pbxPath, "ios.entitlements", "Unity-iPhone");
		capManager.AddiCloud(true, false, false, true, null);
		capManager.WriteToFile();	
	}
}
#endif
