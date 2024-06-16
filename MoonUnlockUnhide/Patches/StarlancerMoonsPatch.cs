using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	internal static class StarlancerMoonsPatch
	{
		public static void onAwake()
		{
			FieldInfo field = Utils.getInternalStaticField("StarlancerMoons.TerminalManagerPatch, StarlancerMoons", "KeywordReplacements");
			if (field == null)
			{
				Plugin.mls.LogWarning("Could not find the field KeywordReplacements in StarlancerMoons.TerminalManagerPatch, StarlancerMoons may not be installed.");
				return;
			}
			Dictionary<string, string> replacements = (Dictionary<string, string>)field.GetValue(null);
			replacements["starlancerzero"] = "starlancerzero";

			Plugin.mls.LogInfo("StarlancerTero is now routable as starlancerzero");
		}
	}
}
