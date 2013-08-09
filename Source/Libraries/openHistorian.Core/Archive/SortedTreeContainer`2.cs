﻿//******************************************************************************************************
//  SortedTreeContainer.cs - Gbtc
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
//  5/22/2012 - Steven E. Chisholm
//       Generated original version of source code. 
//
//******************************************************************************************************

using System;
using GSF.IO.Unmanaged;
using openHistorian.Collections.Generic;
using openHistorian.FileStructure;

namespace openHistorian.Archive
{
    /// <summary>
    /// Encapsolates the ArchiveFileStream, BinaryStream, and BasicTree for a certain tree.
    /// </summary>
    internal class SortedTreeContainer<TKey, TValue>
        : IDisposable
        where TKey : class, new()
        where TValue : class, new()
    {
        #region [ Members ]

        private SubFileStream m_subStream;
        private BinaryStream m_binaryStream;
        private SortedTree<TKey, TValue> m_tree;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        public SortedTreeContainer(TransactionalRead currentTransaction, SubFileName fileName)
        {
            m_subStream = currentTransaction.OpenFile(fileName);
            m_binaryStream = new BinaryStream(m_subStream);
            m_tree = SortedTree<TKey, TValue>.Open(m_binaryStream);
        }

        #endregion

        #region [ Properties ]

        public bool IsDisposed
        {
            get
            {
                return m_disposed;
            }
        }

        #endregion

        #region [ Methods ]

        public TreeScannerBase<TKey, TValue> CreateTreeScanner()
        {
            return m_tree.CreateTreeScanner();
        }

        public void GetKeyRange(TKey lowerBounds, TKey upperBounds)
        {
            m_tree.GetKeyRange(lowerBounds, upperBounds);
        }

        public void Dispose()
        {
            if (!m_disposed)
            {
                try
                {
                    if (m_binaryStream != null)
                    {
                        m_binaryStream.Dispose();
                    }
                    if (m_subStream != null)
                    {
                        m_subStream.Dispose();
                    }
                }
                finally
                {
                    m_subStream = null;
                    m_binaryStream = null;
                    m_tree = null;
                    m_disposed = true;
                }
            }
        }

        #endregion
    }
}