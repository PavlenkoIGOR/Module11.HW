namespace UtilityBotSF.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// Токен Telegram API
        /// </summary>
        public string BotToken
        {
            get; set;
        }
        /// <summary>
        /// Папка загрузки аудио файлов
        /// </summary>
        public string DownloadsFolder
        {
            get; set;
        }
    }
}
