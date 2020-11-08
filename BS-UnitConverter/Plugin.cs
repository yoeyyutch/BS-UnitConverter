using IPA;
using HarmonyLib;
using IPALogger = IPA.Logging.Logger;
using System.Reflection;
using System;
using BS_Utils.Utilities;

namespace BS_UnitConverter
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static Plugin Instance { get; private set; }
		/// <summary>
		/// Use to send log messages through BSIPA.
		/// </summary>
		internal static IPALogger Log { get; private set; }

		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.BS_UnitConverter";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly Harmony harmonyInstance = new Harmony(HARMONYID);

		private MapInfo mapInfo;	

		[Init]
		public Plugin(IPALogger logger)
		{
			Instance = this;
			Log = logger;
		}

		[OnStart]
		public void OnApplicationStart()
		{
			Plugin.Log.Info("OnApplicationStart");
			AddEvents();
			LoadHarmonyPatches();
		}

		public void OnGameSceneLoaded()
		{
			if (mapInfo != null)
			{
				mapInfo = null;
			}
			if (mapInfo == null)
			{
				mapInfo = new MapInfo();
			}
		}

		[OnExit]
		public void OnApplicationQuit()
		{
			UnloadHarmonyPatches();
			RemoveEvents();

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
				Log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				Log.Error("Harmony failed to load");
				Log.Error(e.ToString());
			}
			harmonyPatchesLoaded = true;
		}

		private void AddEvents()
		{
			//BSEvents.menuSceneLoaded += OnMenuSceneLoaded;
			BSEvents.gameSceneLoaded += OnGameSceneLoaded;
			//BSEvents.levelCleared += OnSongExit;
			//BSEvents.levelFailed += OnSongExit;
			//BSEvents.levelQuit += OnSongExit;
			//BSEvents.levelRestarted += OnSongExit;
			//BSEvents.songPaused += OnPause;
			//BSEvents.songUnpaused += OnUnpause;
		}
		private void RemoveEvents()
		{
			//BSEvents.menuSceneLoaded -= OnMenuSceneLoaded;
			BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
			//BSEvents.levelCleared -= OnSongExit;
			//BSEvents.levelFailed -= OnSongExit;
			//BSEvents.levelQuit -= OnSongExit;
			//BSEvents.levelRestarted -= OnSongExit;
			//BSEvents.songPaused -= OnPause;
			//BSEvents.songUnpaused -= OnUnpause;
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
				Log.Info("Harmony patches unloaded");
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
