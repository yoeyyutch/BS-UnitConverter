using UnityEngine;
using HarmonyLib;
using TMPro;

namespace BS_UnitConverter.HarmonyPatches
{
	[HarmonyPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
	class PleyerHeightSettingsControllerRefreshUI
	{
		public static void Postfix(ref TextMeshProUGUI ____text, float ____value)
		{
			const float metersToInches = 39.37f;
			float heightInInches = ____value * metersToInches;
			____text.text = string.Format("{0:0.0}\"", heightInInches);
		}
	}
}

//public static void Postfix(PlayerHeightSettingsController __instance, ref TextMeshProUGUI ____text, float ____value)
//{
//	const float metersToInches = 39.37f;
//	float heightInInches = ____value * metersToInches;
//	____text.text = string.Format("{0:0.0}\"", heightInInches);
//}
