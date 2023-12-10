namespace Core.Utils
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class WalletController
    {
        private readonly PlayerPreferences playerPreferences;
        public WalletController(PlayerPreferences playerPreferences)
        {
            this.playerPreferences = playerPreferences;
        }
    }
}