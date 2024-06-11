using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonUnlockUnhide
{
	[BepInPlugin(modGUID, modName, modVersion)]
	public class Plugin : BaseUnityPlugin
	{
		const string modGUID = "ProjectBots.MoonUnlockUnhide";
		const string modName = "MoonUnlockUnhide";
		const string modVersion = "1.0.0";

		public static Harmony harmony = new Harmony(modGUID);
		public static ManualLogSource mls;


		void Awake()
		{
			mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
			harmony.PatchAll(typeof(MoonPatches));

			mls.LogInfo("MoonUnlockUnhide has been awoken!");
		}
	}
}
