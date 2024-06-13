using HarmonyLib;
using LethalLevelLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	[HarmonyPatch(typeof(HangarShipDoor), "Start")]
	internal static class UnlockUnhidePatch
	{
		private static readonly string[] ignoreMoons = { "Gordion", "Liquidation" };
		public static void Postfix()
		{
			List<ExtendedLevel> allExtendedLevels = PatchedContent.ExtendedLevels;
			foreach (ExtendedLevel level in allExtendedLevels)
			{
				if (ignoreMoons.Contains(level.NumberlessPlanetName))
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
