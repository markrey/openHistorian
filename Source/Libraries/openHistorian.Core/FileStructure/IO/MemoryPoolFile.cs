﻿//******************************************************************************************************
//  MemoryFile.cs - Gbtc
//
//  Copyright © 2013, Grid Protection Alliance.  All Rights Reserved.
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
//  2/1/2013 - Steven E. Chisholm
//       Generated original version of source code. 
//       
//
//******************************************************************************************************

using System;
using GSF.IO.Unmanaged;
using GSF.UnmanagedMemory;

namespace openHistorian.FileStructure.IO
{
    /// <summary>
    /// Provides a in memory stream that uses pages that are pooled in the unmanaged buffer pool.
    /// </summary>
    internal partial class MemoryPoolFile
        : MemoryPoolStreamCore, IDiskMedium
    {
        #region [ Members ]

        private readonly IoSession m_ioSession;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Create a new <see cref="MemoryPoolFile"/>
        /// </summary>
        public MemoryPoolFile(MemoryPool pool)
            : base(pool)
        {
            m_ioSession = new IoSession(this);
        }

        #endregion

        #region [ Properties ]

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Aquire an IO Session.
        /// </summary>
        public BinaryStreamIoSessionBase CreateIoSession()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("MemoryStream");
            return m_ioSession;
        }

        public void FlushWithHeader(FileHeaderBlock headerBlock)
        {
            if (IsDisposed)
                throw new ObjectDisposedException("MemoryStream");
        }

        public void RollbackChanges()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("MemoryStream");
        }

        #endregion
    }
}