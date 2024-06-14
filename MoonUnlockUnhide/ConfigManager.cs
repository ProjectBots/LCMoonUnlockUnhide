using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	internal class ConfigManager
	{
		public static ConfigEntry<string> ignoreMoonsList = null;

		public static void Init(ConfigFile config)
		{
			ignoreMoonsList = config.Bind("General", "ignoreMoonsList", "example1,example2,example3", "List of moons to ignore when unhiding/unlocking moons. Separate with commas.");
		}
	}
}
