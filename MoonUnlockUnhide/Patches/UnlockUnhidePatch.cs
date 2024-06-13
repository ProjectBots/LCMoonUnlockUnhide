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
		private static List<string> ignoreMoons = null;

		public static void Postfix()
		{
			List<ExtendedLevel> allExtendedLevels = PatchedContent.ExtendedLevels;

			if (ignoreMoons == null)
			{
				genIgnoreMoonsList(allExtendedLevels);
			}

			foreach (ExtendedLevel level in allExtendedLevels)
			{
				if (ignoreMoons.Contains(level.NumberlessPlanetName))
					continue;

				// check if the level is hidden or locked
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

		private static void genIgnoreMoonsList(List<ExtendedLevel> allExtendedLevels)
		{
			Plugin.mls.LogInfo("Generating ignoreMoons list");

			ignoreMoons = new List<string>();

			// ignore moons that are not registered in the terminal manager

			Type type = Type.GetType("LethalLevelLoader.TerminalManager, LethalLevelLoader");
			if (type != null)
			{
				System.Reflection.FieldInfo field = type.GetField("routeKeyword", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
				if (field != null)
				{
					TerminalKeyword routeKeyword = (TerminalKeyword)field.GetValue(null);

					foreach (ExtendedLevel level in allExtendedLevels)
					{
						bool found = false;
						foreach (CompatibleNoun item in new List<CompatibleNoun>(routeKeyword.compatibleNouns))
						{
							if(item.result == level.RouteNode)
							{
								found = true;
								break;
							}
						}
						if (!found)
						{
							Plugin.mls.LogInfo("Ignoring " + level.NumberlessPlanetName);
							ignoreMoons.Add(level.NumberlessPlanetName);
						}
					}
				}
				else
				{
					Plugin.mls.LogError("Could not find the field routeKeyword in LethalLevelLoader.TerminalManager");
				}
			}
			else
			{
				Plugin.mls.LogError("Unable to find LethalLevelLoader.TerminalManager");
			}
		}


	}
}
