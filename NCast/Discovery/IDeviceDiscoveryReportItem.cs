

namespace NCast.Discovery
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Interface for device discovery report.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------
    public abstract class DeviceDiscoveryReportItem
    {
        public DeviceType DeviceType { get; set; }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates a <c>Device</c> instance from a <c>DeviceDiscoveryReport</c>
        /// </summary>
        ///
        /// <returns>
        ///     This Report as an <c>IDevice</c>.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        public abstract IDevice ToDevice();
    }
}