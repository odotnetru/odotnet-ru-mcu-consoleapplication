/*
 * http://odotnet.ru/call-xml-rpc-metod-device-query-cisco-using-cisco-mcu-series-api/
 */

using CookComputing.XmlRpc;

using ODotNet.Ru.Tandberg.Interfaces;

namespace ODotNet.Ru.Tandberg
{
    /// <summary>
    /// Реализация работы с Танбергом.
    /// </summary>
    public class TandbergMcu
    {
        /// <summary>
        /// Получить информацию об устройстве.
        /// </summary>
        /// <returns></returns>
        public TandbergDeviceInfo? QueryDeviceInfo()
        {
            TandbergDeviceInfo? ret = null;
            const string mcuXmlRpcUserName = "mcu xml rpc user";
            const string mcuXmlRpcPassword = "mcu xml rpc password";

            try
            {
                var proxy = XmlRpcProxyGen.Create<ITandbergXmlRpc>();

                //MCU URL интерфейса XML-RPC v2.
                proxy.Url = "http://example.com/rpc2";
                //Время ожидания ответа на запрос к MCU в миллисекундах.
                proxy.Timeout = 20;
                proxy.UseEmptyParamsTag = true;
                proxy.KeepAlive = false;

                ret = proxy.QueryDevice(mcuXmlRpcUserName,
                    mcuXmlRpcPassword);
            }
            catch (XmlRpcFaultException ex)
            {
                //TODO Добавить обработку ошибки по вкусу
            }

            return ret;
        }
    }
}
