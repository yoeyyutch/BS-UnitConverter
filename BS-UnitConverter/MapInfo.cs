

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using BS_Utils;


namespace BS_UnitConverter
{
	class MapInfo
	{
		private readonly GameplayCoreSceneSetupData _sceneData;

		private readonly ScoreController _scoreController;

		public ScoreController GetScore() => _scoreController;

		internal static int noteCountTotal;
		internal static int noteCountCurrent;

		internal static int maxPossibleScoreTotal;
		internal static int maxPossibleScoreCurrent;
		internal static int maxPossibleScoreRemaining;

		internal static int score;

		public MapInfo()
		{
			_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			_scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();

			BS_Utils.Utilities.BSEvents.noteWasCut += OnNoteCut;
			BS_Utils.Utilities.BSEvents.noteWasMissed += OnNoteMissed;


			noteCountTotal = _sceneData.difficultyBeatmap.beatmapData.cuttableNotesType;
			maxPossibleScoreTotal = ScoreModel.MaxRawScoreForNumberOfNotes(noteCountTotal);
			Init();

			
			
		}

		void OnNoteCut(NoteData noteData, NoteCutInfo cutInfo, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				noteCountCurrent++;
				score = _scoreController.prevFrameRawScore;
				Plugin.Log.Info("note: " + noteCountCurrent + "Score: " + score);
			}
		}
		void OnNoteMissed(NoteData noteData, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				noteCountCurrent++;
				Plugin.Log.Info("note: " + noteCountCurrent + "Score: " + score);
			}
		}

		void Init()
		{
			noteCountCurrent = 0;
			maxPossibleScoreCurrent = 0;
			maxPossibleScoreRemaining = maxPossibleScoreTotal;
			score = 0;
		}
	}

}
