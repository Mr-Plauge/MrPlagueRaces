using MrPlagueRaces.Core.Loadables;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace MrPlagueRaces.Common.Races
{
	public sealed class RaceLoader : ILoadable
	{
		private static readonly List<Race> Races = new List<Race>();
		private static readonly Dictionary<int, Race> RacesByLegacyIds = new Dictionary<int, Race>();
		private static readonly Dictionary<string, Race> RacesByFullNames = new Dictionary<string, Race>();

		public void Load(Mod mod) { }
		public void Unload()
		{
			Races.Clear();
		}

		public static void AddRace(Race race)
		{
			race.Id = Races.Count;

			Races.Add(race);
			RacesByFullNames.Add(race.FullName, race);

			int? legacyId = race.LegacyId;

			if (legacyId.HasValue)
			{
				RacesByLegacyIds.Add(legacyId.Value, race);
			}
		}

		public static bool TryGetRace(int id, out Race result)
		{
			if (id >= 0 && id < Races.Count)
			{
				result = Races[id];

				return true;
			}

			result = null;

			return false;
		}

		public static bool TryGetRace(string fullName, out Race result) => RacesByFullNames.TryGetValue(fullName, out result);

		public static bool TryGetRaceFromLegacyId(int legacyId, out Race result) => RacesByLegacyIds.TryGetValue(legacyId, out result);
	}
}
