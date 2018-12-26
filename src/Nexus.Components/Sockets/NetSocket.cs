using System;
using System.Net;
using System.Net.Sockets;

namespace Nexus.Components
{
    /// <summary>
    /// Base class for network sockets used by Nexus.
    /// </summary>
    public abstract class NetSocket
    {
        /// <summary>
        /// The low-level underlying socket for this NetSocket.
        /// </summary>
        protected abstract Socket LowSocket { get; set; }
        
        /// <summary>
        /// Bind this socket to an endpoint.
        /// The socket will send/receive packets from this endpoint.
        /// </summary>
        /// <param name="endpoint"> The endpoint to bind to. </param>
        public abstract void Bind(EndPoint endpoint);
        
        /// <summary>
        /// Receive a packet, stores the data into the buffer and the sender by reference.
        /// </summary>
        /// <param name="buffer"> The buffer to which the data will be passed if any. </param>
        /// <param name="offset"> The offset from which to read the packet into the buffer. </param>
        /// <param name="size"> The maximum size of the packet you expect to receive. </param>
        /// <param name="sender"> The packet's sender. </param>
        /// <returns> The size of the packet received. </returns>
        public abstract int ReceiveFrom(byte[] buffer, int offset, int size, ref EndPoint sender);

        /// <summary>
        /// Send a packet to an endpoint.
        /// </summary>
        /// <param name="data"> The packet's data. </param>
        /// <param name="offset"> The offset from which to send the packet's data. </param>
        /// <param name="size"> The size of the packet to send. Any size lower than the data's size will make you lose parts of the data! </param>
        /// <param name="receiver"> The endpoint that should receive the data. </param>
        public abstract void SendTo(byte[] data, int offset, int size, EndPoint receiver);
    }
}