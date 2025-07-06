using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OlympicGamesSite.Helpers
{
    public static class FavoriteManager
    {
        private const string FavoritesKey = "Favorites";

        public static List<int> GetFavorites(ISession session)
        {
            var data = session.GetString(FavoritesKey);
            return data != null ? JsonConvert.DeserializeObject<List<int>>(data) : new List<int>();
        }

        public static void AddFavorite(ISession session, int sportId)
        {
            var favorites = GetFavorites(session);
            if (!favorites.Contains(sportId))
            {
                favorites.Add(sportId);
                session.SetString(FavoritesKey, JsonConvert.SerializeObject(favorites));
            }
        }

        public static void ClearFavorites(ISession session)
        {
            session.Remove(FavoritesKey);
        }
    }
}
