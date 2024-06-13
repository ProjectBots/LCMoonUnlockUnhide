using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	internal static class StarlancerMoonsPatch
	{
		public static void onAwake()
		{
			Type type = Type.GetType("StarlancerMoons.TerminalManagerPatch, StarlancerMoons");
			if (type != null)
			{
				System.Reflection.FieldInfo field = type.GetField("KeywordReplacements", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
				if (field != null)
				{
					Dictionary<string, string> replacements = (Dictionary<string, string>)field.GetValue(null);
					replacements["starlancerzero"] = "starlancerzero";

					Plugin.mls.LogInfo("StarlancerTero is now routable as starlancerzero");
				}
				else
				{
					Plugin.mls.LogError("Could not find the field KeywordReplacements in StarlancerMoons.TerminalManagerPatch");
				}
			}
			else
			{
				Plugin.mls.LogWarning("Unable to find StarlancerMoons.TerminalManagerPatch, StarlancerMoons may not be installed.");
			}
		}
	}
}
