using Blazored.LocalStorage;
using Extensions.Models;

namespace Extensions.Blazored.LocalStorage
{
    public static class SyncExtension
    {
        #region JWT
        public static string GetJWT(this ISyncLocalStorageService storage)
        {
            return storage.GetItemAsString(LocalStorageKey.JWT);
        }
        public static void SetJWT(this ISyncLocalStorageService storage, string token)
        {
            storage.SetItemAsString(LocalStorageKey.JWT, token);
        }
        public static void RemoveJWT(this ISyncLocalStorageService storage)
        {
            storage.RemoveItem(LocalStorageKey.JWT);
        }
        public static bool HaveJWT(this ISyncLocalStorageService storage)
        {
            return !string.IsNullOrEmpty(storage.GetJWT());
        }
        #endregion

        #region User
        public static void SetUser(this ISyncLocalStorageService storage, UserModel model)
        {
            storage.SetItem<UserModel>(LocalStorageKey.User, model);
        }
        public static UserModel? GetUser(this ISyncLocalStorageService storage)
        {
            return storage.GetItem<UserModel>(LocalStorageKey.User) ?? null;
        }
        public static string? GetUserAsString(this ISyncLocalStorageService storage)
        {
            return storage.GetItemAsString(LocalStorageKey.User) ?? null;
        }
        public static void RemoveUser(this ISyncLocalStorageService storage)
        {
            storage.RemoveItem(LocalStorageKey.User);
        }
        public static bool HaveUser(this ISyncLocalStorageService storage)
        {
            return storage.GetUser() != null;
        }
        #endregion

    }
}