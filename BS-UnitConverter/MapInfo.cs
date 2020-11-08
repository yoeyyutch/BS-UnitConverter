using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using BS_Utils;
using System.Collections.Generic;
using System.Collections;

namespace BS_UnitConverter
{
	class MapInfo
	{
		private readonly GameplayCoreSceneSetupData _sceneData;

		private readonly ScoreController _scoreController;

		public ScoreController GetScore() => _scoreController;

		internal static int noteTotal;
		internal static int noteCurrent;
		internal static int notePrevious;

		internal static int maxPossibleScoreTotal;
		internal static int maxPossibleScoreCurrent;
		internal static int maxPossibleScoreRemaining;

		internal static int Score;

		public MapInfo()
		{
			_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			_scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();

			BS_Utils.Utilities.BSEvents.noteWasCut += OnNoteCut;
			BS_Utils.Utilities.BSEvents.noteWasMissed += OnNoteMissed;
			//BS_Utils.Utilities.BSEvents.scoreDidChange += OnScoreChanged;
			_scoreController.scoreDidChangeEvent += OnScoreChanged;


			noteTotal = _sceneData.difficultyBeatmap.beatmapData.cuttableNotesType;
			maxPossibleScoreTotal = ScoreModel.MaxRawScoreForNumberOfNotes(noteTotal);
			Init();	
		}

		void Init()
		{
			Plugin.Log.Info("Level started.");
			Plugin.Log.Info(_sceneData.difficultyBeatmap.level.songName);
			Plugin.Log.Info(_sceneData.difficultyBeatmap.difficulty.ToString());
			Plugin.Log.Info("Note Count: " + noteTotal);

			noteCurrent = 0;
			notePrevious = 0;
			
			maxPossibleScoreCurrent = 0;
			maxPossibleScoreRemaining = maxPossibleScoreTotal;
			Score = 0;
		}
		
		void OnNoteCut(NoteData noteData, NoteCutInfo cutInfo, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				noteCurrent++;
			}
		}
		void OnNoteMissed(NoteData noteData, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				noteCurrent++;
			}
		}

		void OnScoreChanged(int score, int modifiedScore)
		{
			Score = score;
			Plugin.Log.Info("note: " + noteCurrent + "/" + noteTotal + " Score: " + Score + "/" + CurrentMaxScore(noteCurrent));

		}

		int CurrentMaxScore(int notes)
		{
			int max = ScoreModel.MaxRawScoreForNumberOfNotes(notes);
			return max;
		}
	}

}
