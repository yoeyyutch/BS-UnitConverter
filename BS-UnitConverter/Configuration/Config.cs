namespace BS_UnitConverter.Configuration
{
	static public class Config
	{
		static BS_Utils.Utilities.Config config;


		static readonly string s = "Settings";

		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(Plugin.PluginName);
		}

		internal static bool UseMetricHeight
		{
			get
			{
				return config.GetBool(s, nameof(UseMetricHeight), true, true);
			}
			set
			{
				config.SetBool(s, nameof(UseMetricHeight), value);
			}
		}

		internal static int DecimalPrecision
		{ 
			get
			{
				return config.GetInt(s, nameof(DecimalPrecision), 3, true);
			}
			set 
			{
				config.SetInt(s, nameof(DecimalPrecision), value);
			}
		}

		internal static float PlayerHeight
		{
			get
			{
				return (config.GetFloat(s, nameof(PlayerHeight), 1.8f, false));
			}

			set
			{
				config.SetFloat(s, nameof(PlayerHeight), value);
			}
		}
	}
}
