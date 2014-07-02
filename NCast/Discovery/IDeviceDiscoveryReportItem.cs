

namespace NCast.Discovery
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Interface for device discovery report.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------
    public interface IDeviceDiscoveryReportItem
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Creates a <c>Device</c> instance from a <c>DeviceDiscoveryReport</c>
        /// </summary>
        ///
        /// <returns>
        ///     This Report as an <c>IDevice</c>.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------
        IDevice ToDevice();
    }
}