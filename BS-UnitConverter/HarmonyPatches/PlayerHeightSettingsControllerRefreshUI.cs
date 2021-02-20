using UnityEngine;
using HarmonyLib;
using TMPro;
using System.Globalization;
using BS_UnitConverter.Configuration;

namespace BS_UnitConverter.HarmonyPatches
{
	[HarmonyPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
	class PleyerHeightSettingsControllerRefreshUI
	{
		const float metersToInches = 39.37f;

		public static void Postfix(ref TextMeshProUGUI ____text, float ____value)
		{
			NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
			nfi.NumberDecimalDigits = Config.DecimalPrecision;
			string playerHeight = Config.UseMetricHeight ? ____value.ToString("N", nfi) : $"{(____value * metersToInches).ToString("N", nfi)}\"";

			if (Config.PlayerHeight != ____value)
			{
				Config.PlayerHeight = ____value;
				Plugin.Log.Info("Player Height changed to " + playerHeight);
			}

			____text.text = playerHeight;

		}
	}
}
/*
public static float JumpOffsetYForPlayerHeight(float playerHeight)
{
	return Mathf.Clamp((playerHeight - 1.8f) * 0.5f, -0.2f, 0.6f);
	ex. playerHeight = 1.5; -0.3 * 0.5
	
	(h-1.8)*0.5 = -0.2	
	 h-1.8 = -0.4

}

1.5-1.8=-.3

//float heightInInches = ____value * metersToInches;
//____text.text = string.Format("{0:0.0}\"", heightInInches);
//PlayerHeight = ____value;

//public static void Postfix(PlayerHeightSettingsController __instance, ref TextMeshProUGUI ____text, float ____value)
//{
//	const float metersToInches = 39.37f;
//	float heightInInches = ____value * metersToInches;
//	____text.text = string.Format("{0:0.0}\"", heightInInches);
//}
*/