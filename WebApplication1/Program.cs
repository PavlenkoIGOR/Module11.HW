using System.Text;
using Telegram.Bot;
using UtilityBotSF.Controllers;
using UtilityBotSF.Services;
using UtilityBotSF.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace UtilityBotSF
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // ������, ���������� �� ���������� ��������� ���� ����������
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // ������ ������������
                .UseConsoleLifetime() // ��������� ������������ ���������� �������� � �������
                .Build(); // ��������

            Console.WriteLine("������ �������");
            // ��������� ������
            await host.RunAsync();
            Console.WriteLine("������ ����������");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            // ���������� ����������� ��������� � ������
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "",
                BotToken = "5938082649:AAFC_k1rVaZo9x2SwvDtirUcIH7ugs3LToU",
            };
        }
    }
}


//BotToken = "5938082649:AAFC_k1rVaZo9x2SwvDtirUcIH7ugs3LToU"

