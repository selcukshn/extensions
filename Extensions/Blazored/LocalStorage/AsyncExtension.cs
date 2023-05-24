using Blazored.LocalStorage;
using Extensions.Models;

namespace Extensions.Blazored.LocalStorage
{
    public static class AsyncExtension
    {
        #region JWT
        public static async Task<string> GetJWTAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsStringAsync(LocalStorageKey.JWT);
        }
        public static async Task SetJWTAsync(this ILocalStorageService storage, string token)
        {
            await storage.SetItemAsStringAsync(LocalStorageKey.JWT, token);
        }
        public static async Task RemoveJWTAsync(this ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(LocalStorageKey.JWT);
        }
        public static async Task<bool> HaveJWTAsync(this ILocalStorageService storage)
        {
            return !string.IsNullOrEmpty(await storage.GetJWTAsync());
        }
        #endregion

        #region User
        public static async Task SetUserAsync(this ILocalStorageService storage, UserModel model)
        {
            await storage.SetItemAsync<UserModel>(LocalStorageKey.User, model);
        }
        public static async Task<UserModel?> GetUserAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsync<UserModel>(LocalStorageKey.User) ?? null;
        }
        public static async Task<string?> GetUserAsStringAsync(this ILocalStorageService storage)
        {
            return await storage.GetItemAsStringAsync(LocalStorageKey.User) ?? null;
        }
        public static async Task RemoveUserAsync(this ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(LocalStorageKey.User);
        }
        public static async Task<bool> HaveUserAsync(this ILocalStorageService storage)
        {
            return await storage.GetUserAsync() != null;
        }
        #endregion
    }
}