using UnityEngine;

namespace BS_UnitConverter
{
	public struct NoteDebrisData
	{
		ColorType ColorType;
		Vector3 NotePos;
		Vector3 NoteRot;
		Vector3 CutPoint;
		Vector3 CutNormal;
		Vector3 Force;
		Vector3 Torque;
		float Lifetime;

		public NoteDebrisData(ColorType colorType, Vector3 notePos, Quaternion noteRot, Vector3 cutPoint, Vector3 cutNormal, Vector3 force, Vector3 torque, float lifeTime)
		{
			ColorType = colorType;
			NotePos = notePos;
			NoteRot = noteRot.eulerAngles;
			CutPoint = cutPoint;
			CutNormal = cutNormal;
			Force = force;
			Torque = torque;
			Lifetime = lifeTime;
		}

		public string GetDebrisData(string[] debrisData)
		{
			string[] array = debrisData;
			string output = string.Join(", ", array);
			Plugin.Log.Info(output);
			return output;
		}

		public string[] AllNoteDebrisData()
		{
			string[] array = new string[]
			{
				FormatColorTypeLR(ColorType),
				NotePos.ToString("0.000"),
				NoteRot.ToString("0.000"),
				CutPoint.ToString("0.000"),
				CutNormal.ToString("0.000"),
				Force.ToString("0.00"),
				Torque.ToString("0.00"),
				Lifetime.ToString("0.00"),
			};

			return array;
		}

		public string[] PositionData()
		{
			string[] array = new string[]
			{
				FormatColorTypeLR(ColorType),
				NotePos.ToString("0.000"),
				CutPoint.ToString("0.000"),
			};

			return array;
		}

		private string FormatColorTypeLR(ColorType colorType)
		{
			string hand = colorType.ToString();
			if (hand == "ColorA")
				return "L";
			else if (hand == "ColorB")
				return "R";
			else
				return hand;



		}
	}
}
