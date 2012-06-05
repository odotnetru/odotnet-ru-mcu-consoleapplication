/*
 * http://odotnet.ru/call-xml-rpc-metod-device-query-cisco-using-cisco-mcu-series-api/
 */

using System;

using ODotNet.Ru.Tandberg;
using ODotNet.Ru.Tandberg.Interfaces;

namespace ODotNet.Ru.MCU.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var mcu = new TandbergMcu();
            var result = mcu.QueryDeviceInfo();

            if (null != result)
            {
                var info = ((TandbergDeviceInfo) result);

                //Пример вывода части информации полученной с помощью запроса.

                Console.WriteLine("Модель тандберга: {0}", info.model);
                Console.WriteLine("Версия программного обеспечения тандберга: {0}", info.softwareVersion);
                Console.WriteLine("Версия билда программного обеспечения тандберга: {0}", info.buildVersion);
                Console.WriteLine("Версия API тандберга: {0}", info.apiVersion);
                Console.WriteLine("Текущее время тандберга: {0}", info.currentTime);
                Console.WriteLine("Всего видео портов: {0}", info.totalVideoPorts);
                Console.WriteLine("Всего дополнительных аудио портов: {0}", info.totalAudioOnlyPorts);
            }
        }
    }
}
