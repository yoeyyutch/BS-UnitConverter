
using HarmonyLib;
using UnityEngine;
using BS_UnitConverter.Configuration;

namespace BS_UnitConverter.HarmonyPatches
{
	[HarmonyPatch(typeof(NoteDebris), "Init")]
	//[HarmonyPatch("Init")]
	class NoteDebrisPatch
	{


		public static void Prefix(ColorType colorType, Vector3 notePos, Quaternion noteRot, Vector3 cutPoint, Vector3 cutNormal, Vector3 force, Vector3 torque, float lifeTime)
		{
			if (Config.CollectDebrisData)
			{
				NoteDebrisData debrisData = new NoteDebrisData(colorType, notePos, noteRot, cutPoint, cutNormal, force, torque, lifeTime);
				_ = debrisData.GetDebrisData(debrisData.AllNoteDebrisData());
			}

		}
	}
}

//NoteData note = initTransform.GetComponentInParent<NoteController>().noteData;
//Vector3 notePos = CustomNoteDebris.HeadPosition() - initTransform.position;
//float angle = Vector2.Angle(notePos, force);
//float a = (angle / 180) + 1f;
//bool debrisObstructsView = CustomNoteDebris.DebrisObstructsView(angle);

//if (note.id < 10) Logger.LogDebrisData("In :", initTransform, force, lifeTime, angle);

//force = Vector3.Scale(a * CustomNoteDebris.ForceAdjustment(), force);
//lifeTime = CustomNoteDebris.LifetimeAdjustment(angle, debrisObstructsView, note.timeToNextBasicNote);

//if (note.id < 10) Logger.LogDebrisData("Out :", initTransform, force, lifeTime, angle);
