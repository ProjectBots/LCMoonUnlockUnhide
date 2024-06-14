using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalLevelLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	[BepInPlugin(modGUID, modName, modVersion)]
	[BepInDependency("imabatby.lethallevelloader", BepInDependency.DependencyFlags.HardDependency)]
	public class Plugin : BaseUnityPlugin
	{
		const string modGUID = "ProjectBots.MoonUnlockUnhide";
		const string modName = "MoonUnlockUnhide";
		const string modVersion = "1.2.0";

		public static Harmony harmony = new Harmony(modGUID);
		public static ManualLogSource mls;

		void Awake()
		{
			mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

			ConfigManager.Init(Config);

			harmony.PatchAll(typeof(UnlockUnhidePatch));

			StarlancerMoonsPatch.onAwake();

			mls.LogInfo("MoonUnlockUnhide has been awoken!");
		}

	}
}
