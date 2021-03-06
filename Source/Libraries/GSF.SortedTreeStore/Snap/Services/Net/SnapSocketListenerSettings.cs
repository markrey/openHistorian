﻿//******************************************************************************************************
//  SnapSocketListenerSettings.cs - Gbtc
//
//  Copyright © 2014, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  05/16/2014 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using System.Data;
using System.IO;
using System.Net;
using GSF.Immutable;
using GSF.IO;

namespace GSF.Snap.Services.Net
{
    /// <summary>
    /// Contains the basic config for a socket interface.
    /// </summary>
    public class SnapSocketListenerSettings
        : SettingsBase<SnapSocketListenerSettings>
    {
        /// <summary>
        /// Defines the default network port for a <see cref="SnapSocketListener"/>.
        /// </summary>
        public const int DefaultNetworkPort = 38402;

        /// <summary>
        /// Defines the default network IP address for the <see cref="SnapSocketListener"/>.
        /// </summary>
        public const string DefaultIPAddress = "";

        /// <summary>
        /// A server name that must be supplied at startup before a key exchange occurs.
        /// </summary>
        public const string DefaultServerName = "openHistorian";

        /// <summary>
        /// The local IP address to host on. Leave empty to bind to all local interfaces.
        /// </summary>
        private string m_localIpAddress = DefaultIPAddress;

        /// <summary>
        /// The local TCP port to host on. 
        /// </summary>
        private int m_localTcpPort = DefaultNetworkPort;

        /// <summary>
        /// A server name that must be supplied at startup before a key exchange occurs.
        /// </summary>
        private string m_serverName = DefaultServerName;

        /// <summary>
        /// A list of all windows users that are allowed to connnect to the historian.
        /// </summary>
        private ImmutableList<string> m_users = new ImmutableList<string>();

        /// <summary>
        /// Force the use of Ssl for all clients connecting to this socket.
        /// </summary>
        private bool m_forceSsl = false;

        /// <summary>
        /// Gets the local <see cref="IPEndPoint"/> from the values in <see cref="m_localIpAddress"/> and <see cref="m_localTcpPort"/>
        /// </summary>
        public IPEndPoint LocalEndPoint
        {
            get
            {
                if (string.IsNullOrWhiteSpace(m_localIpAddress))
                {
                    return new IPEndPoint(IPAddress.Any, m_localTcpPort);
                }
                return new IPEndPoint(IPAddress.Parse(m_localIpAddress), m_localTcpPort);
            }
        }

        /// <summary>
        /// A list of all windows users that are allowed to connnect to the historian.
        /// </summary>
        public ImmutableList<string> Users
        {
            get
            {
                return m_users;
            }
        }

        /// <summary>
        /// Force the use of Ssl for all clients connecting to this socket.
        /// </summary>
        public bool ForceSsl
        {
            get
            {
                return m_forceSsl;
            }
            set
            {
                TestForEditable();
                m_forceSsl = value;
            }
        }

        /// <summary>
        /// The local TCP port to host on. 
        /// </summary>
        public int LocalTcpPort
        {
            get
            {
                return m_localTcpPort;
            }
            set
            {
                TestForEditable();
                m_localTcpPort = value;
            }
        }

        /// <summary>
        /// The local IP address to host on. Leave empty to bind to all local interfaces.
        /// </summary>
        public string LocalIpAddress
        {
            get
            {
                return m_localIpAddress;
            }
            set
            {
                TestForEditable();
                m_localIpAddress = value;
            }
        }

        public bool DefaultUserCanRead = false;
        public bool DefaultUserCanWrite = false;
        public bool DefaultUserIsAdmin = false;

        public override void Save(Stream stream)
        {
            stream.Write((byte)1);
        }

        public override void Load(Stream stream)
        {
            TestForEditable();
            byte version = stream.ReadNextByte();
            switch (version)
            {
                case 1:

                    break;
                default:
                    throw new VersionNotFoundException("Unknown Version Code: " + version);

            }
        }

        public override void Validate()
        {
            //ToDo: Validate later when this class is fixed.
        }
    }
}
