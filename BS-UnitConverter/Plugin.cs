using IPA;
using HarmonyLib;
using IPALogger = IPA.Logging.Logger;
using System.Reflection;
using System;
using Config = BS_UnitConverter.Configuration.Config;

namespace BS_UnitConverter
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static string PluginName => "BS_UnitConverter";
		internal static Plugin Instance { get; private set; }
		internal static IPALogger Log { get; private set; }

		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.BS_UnitConverter";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly Harmony harmonyInstance = new Harmony(HARMONYID);

		//private MapInfo mapInfo;	

		[Init]
		public Plugin(IPALogger logger)
		{
			Instance = this;
			Log = logger;
			Config.Init();
		}

		[OnStart]
		public void OnApplicationStart()
		{
			Log.Info("OnApplicationStart");
			if (Config.CollectDebrisData)
				Log.Info("Colortype, NoteP, NoteR, OffsetP, OffsetR, CutP, CutN, F, T, L");
			//AddEvents();
			LoadHarmonyPatches();
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			Log.Info("OnApplicationQuit");
		
			//Log.Info($"Songs Played: {MapInfo.SongsPlayed}");
			UnloadHarmonyPatches();
			//RemoveEvents();
		}

		internal void LoadHarmonyPatches()
		{
			if (harmonyPatchesLoaded)
			{
				//Logger.Log.Info("Harmony patches already loaded. Skipping...");
				return;
			}
			try
			{
				harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
				//Log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				Log.Error("Harmony failed to load");
				Log.Error(e.ToString());
			}
			harmonyPatchesLoaded = true;
		}
		internal void UnloadHarmonyPatches()
		{
			if (!harmonyPatchesLoaded)
			{
				return;
			}
			try
			{
				harmonyInstance.UnpatchAll(HARMONYID);
				//Log.Info("Harmony patches unloaded");
			}
			catch (Exception e)
			{
				Log.Error("Harmony failed to unload");
				Log.Error(e.ToString());
			}
			harmonyPatchesLoaded = false;
		}

	}
}

//public void OnGameSceneLoaded()
//{
//	if (mapInfo != null)
//	{
//		mapInfo = null;
//	}
//	if (mapInfo == null)
//	{
//		mapInfo = new MapInfo();
//	}
//}

//public void OnMenuSceneLoaded()
//{


//}

//public void OnSongExit(StandardLevelScenesTransitionSetupDataSO level, LevelCompletionResults results)
//{

//	Log.Info(results.levelEndStateType.ToString());
//	Log.Info(results.rawScore.ToString());
//	Log.Info(results.levelEndAction.ToString());
//mapInfo.RemoveEvents();

//if (mapInfo != null)
//{
//	mapInfo = null;
//}
//mapInfo.Unsub();
//}




//private void AddEvents()
//{
//	//BSEvents.menuSceneLoaded += OnMenuSceneLoaded;
//	BSEvents.gameSceneLoaded += OnGameSceneLoaded;
//	BSEvents.levelCleared += OnSongExit;
//	BSEvents.levelFailed += OnSongExit;
//	BSEvents.levelQuit += OnSongExit;
//	//BSEvents.levelRestarted += OnSongExit;
//	//BSEvents.songPaused += OnPause;
//	//BSEvents.songUnpaused += OnUnpause;
//	//BSEvents.noteWasCut += OnNoteCut;
//}
//private void RemoveEvents()
//{
//	//BSEvents.menuSceneLoaded -= OnMenuSceneLoaded;
//	BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
//	BSEvents.levelCleared -= OnSongExit;
//	BSEvents.levelFailed -= OnSongExit;
//	BSEvents.levelQuit -= OnSongExit;
//	//BSEvents.levelRestarted -= OnSongExit;
//	//BSEvents.songPaused -= OnPause;
//	//BSEvents.songUnpaused -= OnUnpause;
//}
