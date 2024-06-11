using HarmonyLib;
using LethalLevelLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	[HarmonyPatch(typeof(HangarShipDoor), "Start")]
	public class MoonPatches
	{
		private static string[] ignoreMoons = { "GordionExtendedLevel", "LiquidationExtendedLevel" };
		static void Postfix()
		{
			List<ExtendedLevel> allExtendedLevels = PatchedContent.ExtendedLevels;
			foreach (ExtendedLevel level in allExtendedLevels)
			{
				if (ignoreMoons.Contains(level.name))
					continue;

				if (level.IsRouteHidden)
				{
					Plugin.mls.LogInfo("Unhiding " + level.NumberlessPlanetName);
					level.IsRouteHidden = false;
				}
				if (level.IsRouteLocked)
				{
					Plugin.mls.LogInfo("Unlocking " + level.NumberlessPlanetName);
					level.IsRouteLocked = false;
				}
			}
		}
	}
}
