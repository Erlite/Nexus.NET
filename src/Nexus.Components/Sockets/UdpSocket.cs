using System;
using System.Net;
using System.Net.Sockets;

namespace Nexus.Components
{
    /// <summary>
    /// Creates a new UdpSocket used for UDP communication under IPv4.
    /// </summary>
    public sealed class UdpSocket : NetSocket, IDisposable
    {
        public UdpSocket()
        {
            LowSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        
        /// <inheritdoc cref="NetSocket.LowSocket"/>
        protected override Socket LowSocket { get; set; }

        /// <summary>
        /// Returns true if the socket has a packet waiting to be handled.
        /// </summary>
        public bool PacketAvailable => LowSocket.Available > 0;

        /// <inheritdoc cref="NetSocket.Bind"/> 
        public override void Bind(EndPoint endpoint)
        {
            LowSocket.Bind(endpoint);
        }
        
        /// <inheritdoc cref="NetSocket.ReceiveFrom"/>
        public override int ReceiveFrom(byte[] buffer, int offset, int size, ref EndPoint sender)
        {
            // TODO: Implement packet protocol verification and sanity checks.
            return LowSocket.ReceiveFrom(buffer, offset, size, SocketFlags.None, ref sender);
        }

        /// <inheritdoc cref="NetSocket.SendTo"/>
        public override void SendTo(byte[] data, int offset, int size, EndPoint receiver)
        {
            LowSocket.SendTo(data, offset, size, SocketFlags.None, receiver);
        }

        /// <summary>
        /// Shutdown the socket and disposes of all resources used by this socket.
        /// </summary>
        public void Dispose()
        {
            LowSocket?.Close();
            LowSocket?.Shutdown(SocketShutdown.Both);
            LowSocket?.Dispose();
        }
    }
}