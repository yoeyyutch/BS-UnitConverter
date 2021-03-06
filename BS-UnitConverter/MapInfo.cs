﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using BS_Utils.Utilities;
using System.Collections.Generic;
using System.Collections;

namespace BS_UnitConverter
{
	//public class MapInfo
	//{
	//	private readonly GameplayCoreSceneSetupData _sceneData;
	//	private readonly ScoreController _scoreController;

	//	//public ScoreController GetScore() => _scoreController;

	//	internal int MapNoteCount;
	//	internal int MapMaxScore;

	//	internal int CurrentNote;

	//	internal int CurrentScore;
	//	private int nextNote;

	//	internal int MaxPossibleScore;
	//	internal float MaxPercentPossible;

	//	public static int SongsPlayed = 0;

	//	public MapInfo()
	//	{
	//		_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
	//		_scoreController = Resources.FindObjectsOfTypeAll<ScoreController>().Last();
			 

	//		Init();
	//		AddEvents();
	//		LogMapInfo();
	//	}

	//	void Init()
	//	{
	//		MapNoteCount = _sceneData.difficultyBeatmap.beatmapData.cuttableNotesType;
	//		MapMaxScore = ScoreModel.MaxRawScoreForNumberOfNotes(MapNoteCount);
	//		CurrentNote = 0;
	//		nextNote = 2;
	//		CurrentScore = 0;
	//		MaxPercentPossible = 100f;
	//		SongsPlayed++;
	//	}

	//	void OnNoteCut(NoteData noteData, NoteCutInfo cutInfo, int multiplier)
	//	{
	//		if(cutInfo.swingRatingCounter.didFinish)
	//		{ }

	//		if (noteData.colorType != ColorType.None)
	//		{
	//			CurrentNote++;
	//		}
	//	}
	//	void OnNoteMissed(NoteData noteData, int multiplier)
	//	{
	//		if (noteData.colorType != ColorType.None)
	//		{
	//			CurrentNote++;
	//		}
	//	}

	//	void OnScoreChanged(int score, int modifiedScore)
	//	{

	//		if (nextNote > CurrentNote)
	//		{
	//			CurrentScore = score;
	//			if (CurrentNote == MapNoteCount)
	//			{
	//				CalculateMax(CurrentNote);
	//			}
	//			else
	//			{
	//				return;
	//			}
	//		}
	//		else if (nextNote == CurrentNote)
	//		{
	//			int n = CurrentNote - 1;
	//			CalculateMax(n);
	//			nextNote++;
	//		}

	//		CurrentScore = score;

	//		if (MapMaxScore != 0)
	//		{
	//			//var m = MaxPercent();
	//			//MaxPercentPossible =(MyMaxScorePossible() / MapMaxScore)*100f;

	//		}

	//	}
	//	void CalculateMax(int note)
	//	{
	//		int maxsofar = ScoreModel.MaxRawScoreForNumberOfNotes(note);
	//		int maxremaining = MapMaxScore - maxsofar;
	//		int pointsMissed = maxsofar - CurrentScore;
	//		MaxPossibleScore = CurrentScore + maxremaining;
	//		MaxPercentPossible = MapMaxScore != 0 ? (float)MaxPossibleScore / (float)MapMaxScore * 100f : 100f;
	//		Plugin.Log.Info($"{note}, {CurrentScore}, Missed:{pointsMissed}, {MaxPercentPossible:0.00}%");
	//		return;

	//	}

	//	//int MaxScoreSoFar() => ScoreModel.MaxRawScoreForNumberOfNotes(CurrentNote);

	//	//int MaxScoreForRemainingNotes() => MapMaxScore - MaxScoreSoFar();

	//	//int MyMaxScorePossible() => CurrentScore + MaxScoreForRemainingNotes();

	//	public void AddEvents()
	//	{
	//		BSEvents.noteWasCut += OnNoteCut;
	//		BSEvents.noteWasMissed += OnNoteMissed;
	//		_scoreController.scoreDidChangeEvent += OnScoreChanged;
	//	}

	//	public void RemoveEvents()
	//	{
	//		BSEvents.noteWasCut -= OnNoteCut;
	//		BSEvents.noteWasMissed -= OnNoteMissed;
	//		_scoreController.scoreDidChangeEvent -= OnScoreChanged;
	//	}

	//	public void LogMapInfo()
	//	{
	//		Plugin.Log.Info("Level started.");
	//		Plugin.Log.Info(_sceneData.difficultyBeatmap.level.songName);
	//		Plugin.Log.Info($"Max score: {MapMaxScore}");
	//		Plugin.Log.Info(_sceneData.difficultyBeatmap.difficulty.ToString());
	//		Plugin.Log.Info("Note Count: " + MapNoteCount);
	//	}

	//	//public void Unsub()
	//	//{
	//	//	BSEvents.noteWasCut -= OnNoteCut;
	//	//}
	//}

}
