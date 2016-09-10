// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HomeRoom_Mobile.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string ApiTokenKey = "apitoken_key";
    private static readonly string ApiToken = string.Empty;

    #endregion


    public static string ApiAuthToken
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(ApiTokenKey, ApiToken);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(ApiTokenKey, value);
      }
    }

  }
}