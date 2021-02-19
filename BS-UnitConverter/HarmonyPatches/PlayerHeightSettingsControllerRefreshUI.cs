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


		public static void Postfix(ref TextMeshProUGUI ____text, float ____value)
		{
			if (Config.PlayerHeight != ____value) Config.PlayerHeight = ____value; 
			const float metersToInches = 39.37f;
			
			NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
			nfi.NumberDecimalDigits = Config.DecimalPrecision;

			____text.text = Config.UseMetricHeight ? ____value.ToString("N", nfi) : (____value * metersToInches).ToString("N", nfi);


		}
	}
}


//float heightInInches = ____value * metersToInches;
//____text.text = string.Format("{0:0.0}\"", heightInInches);
//PlayerHeight = ____value;

//public static void Postfix(PlayerHeightSettingsController __instance, ref TextMeshProUGUI ____text, float ____value)
//{
//	const float metersToInches = 39.37f;
//	float heightInInches = ____value * metersToInches;
//	____text.text = string.Format("{0:0.0}\"", heightInInches);
//}
