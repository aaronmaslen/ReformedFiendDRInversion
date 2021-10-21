using System;

using Kingmaker.Blueprints.Classes;
using Kingmaker.Localization;

namespace ReformedFiendDRInversion
{
	public static partial class Utility
	{
		public static class Feat
		{
			// F# has runtime access modifier checks on fields so we have to do this in C#
			public static void SetDescription(BlueprintFeature feat, string description)
				=> LocalizationManager.CurrentPack.Strings[feat.m_Description.Key] = description;

			public static void ChangeDescription(BlueprintFeature feat, Func<string, string> descriptionFunc)
				=> SetDescription(feat, descriptionFunc(feat.Description));
		}
	}
}
