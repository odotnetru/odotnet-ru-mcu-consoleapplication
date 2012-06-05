/*
 * http://odotnet.ru/call-xml-rpc-metod-device-query-cisco-using-cisco-mcu-series-api/
 */

using System;

using CookComputing.XmlRpc;

namespace ODotNet.Ru.Tandberg.Interfaces
{
    /// <summary>
    /// Информация по устройству.
    /// </summary>
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct TandbergDeviceInfo
    {
        /// <summary>
        /// The system’s current time (UTC).
        /// </summary>
        //public DateTime currentTime;

        public DateTime currentTime { get; set; }

        /// <summary>
        /// The date and time at which the system was last restarted.
        /// </summary>
        public DateTime restartTime { get; set; }

        /// <summary>
        /// The serial number of the MCU.
        /// </summary>
        public string serial { get; set; }

        /// <summary>
        /// The software version of the running software.
        /// </summary>
        public string softwareVersion { get; set; }

        /// <summary>
        /// The build version of the running software.
        /// </summary>
        public string buildVersion { get; set; }

        /// <summary>
        /// The model of this MCU, e.g. "...... MCU 4210".
        /// </summary>
        public string model { get; set; }

        /// <summary>
        /// The version number of the API implemented by this MCU.
        /// </summary>
        public string apiVersion { get; set; }

        /// <summary>
        /// Currently, only contains the string "feature" with a short description of the feature.
        /// </summary>
        public ActivatedMcuFeatures[] activatedFeatures { get; set; }

        /// <summary>
        /// The total number of video ports on the MCU.
        /// </summary>
        public int totalVideoPorts { get; set; }

        /// <summary>
        ///The total number of additional audio-only ports on the MCU.
        /// </summary>
        public int totalAudioOnlyPorts { get; set; }

        /// <summary>
        /// The total number of streaming and content ports on the MCU. Only provided if non-zero.
        /// </summary>
        public int totalStreamingAndContentPorts { get; set; }

        /// <summary>
        /// enabled or disabled, depending on the Media Port Reservation configuration setting. Only present on MCU products.
        /// </summary>
        public string portReservationMode { get; set; }

        /// <summary>
        /// One of cif or 4cif.
        /// </summary>
        public string maxVideoResolution { get; set; }

        /// <summary>
        /// Array of structs containing a type element and a count element. The type element can be one of sd, hd, hdPlus, or fullhd. count is an integer indicating the number of video ports allocated.
        /// </summary>
        public VideoPort[] videoPortAllocation { get; set; }

        public int uptime { get; set; }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct VideoPort
    {
        public string type { get; set; }
        public int count { get; set; }
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ActivatedMcuFeatures
    {
        public string feature { get; set; }
    }

    /// <summary>
    /// XML-RPC интерфейс к Tandberg.
    /// </summary>
    public interface ITandbergXmlRpc : IXmlRpcProxy
    {
        /// <summary>
        /// Получить информацию об устройстве.
        /// </summary>
        /// <param name="authenticationUser">Имя пользователя.</param>
        /// <param name="authenticationPassword">Пароль.</param>
        /// <returns></returns>
        [XmlRpcMethod("device.query", StructParams = true)]
        TandbergDeviceInfo QueryDevice(string authenticationUser, string authenticationPassword);
    }
}
