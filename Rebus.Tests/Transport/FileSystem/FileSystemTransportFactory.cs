﻿using System;
using System.IO;
using Rebus.Tests.Contracts.Transports;
using Rebus.Transport;
using Rebus.Transport.FileSystem;

namespace Rebus.Tests.Transport.FileSystem
{
    public class FileSystemTransportFactory : ITransportFactory
    {
        readonly string _baseDirectory;

        public FileSystemTransportFactory()
        {
            _baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "messages");

            CleanUp();
        }

        public ITransport CreateOneWayClient()
        {
            return new FileSystemTransport(_baseDirectory, null);
        }

        public ITransport Create(string inputQueueAddress)
        {
            return new FileSystemTransport(_baseDirectory, inputQueueAddress);
        }

        public void CleanUp()
        {
            if (Directory.Exists(_baseDirectory))
            {
                Directory.Delete(_baseDirectory, true);
            }
        }
    }
}