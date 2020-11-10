using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using BS_Utils.Utilities;
using System.Collections.Generic;
using System.Collections;

namespace BS_UnitConverter
{
	public class MapInfo
	{
		private readonly GameplayCoreSceneSetupData _sceneData;
		private readonly ScoreController _scoreController;

		//public ScoreController GetScore() => _scoreController;

		internal int MapNoteCount;
		internal int MapMaxScore;

		internal int NotesCompleted;

		internal int Score;

		internal float MaxPercentPossible;

		public static int SongsPlayed = 0;

		public MapInfo()
		{
			_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			_scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().First();

			SongsPlayed++;
			Init();
		}

		void Init()
		{
			BSEvents.noteWasCut += OnNoteCut;
			BSEvents.noteWasMissed += OnNoteMissed;
			_scoreController.scoreDidChangeEvent += OnScoreChanged;

			MapNoteCount = _sceneData.difficultyBeatmap.beatmapData.cuttableNotesType;
			MapMaxScore = ScoreModel.MaxRawScoreForNumberOfNotes(MapNoteCount);


			NotesCompleted = 0;
			Score = 0;
			MaxPercentPossible = 100f;

			Plugin.Log.Info("Level started.");
			Plugin.Log.Info(_sceneData.difficultyBeatmap.level.songName);
			Plugin.Log.Info(_sceneData.difficultyBeatmap.difficulty.ToString());
			Plugin.Log.Info("Note Count: " + MapNoteCount);
		}

		void OnNoteCut(NoteData noteData, NoteCutInfo cutInfo, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				NotesCompleted++;
			}
		}
		void OnNoteMissed(NoteData noteData, int multiplier)
		{
			if (noteData.colorType != ColorType.None)
			{
				NotesCompleted++;
			}
		}

		void OnScoreChanged(int score, int modifiedScore)
		{
			Score = score;
			if (MapMaxScore != 0)
			{
				MaxPercentPossible =(MyMaxScorePossible() / MapMaxScore)*100f;
				Plugin.Log.Info($"{NotesCompleted}: {MaxPercentPossible}%");
			}
			//Plugin.Log.Info("note: " + NotesCompleted + "/" + MapNoteCount + " Score: " + Score + "/" + MaxScoreSoFar());
		}

		int MaxScoreSoFar() => ScoreModel.MaxRawScoreForNumberOfNotes(NotesCompleted);

		int MaxScoreForRemainingNotes() => MapMaxScore - MaxScoreSoFar();

		int MyMaxScorePossible() => Score + MaxScoreForRemainingNotes();

		//public void Unsub()
		//{
		//	BSEvents.noteWasCut -= OnNoteCut;
		//}
	}

}
