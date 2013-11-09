﻿using System;
using System.Collections.Generic;
using System.IO;
using GSF.SortedTreeStore;
using GSF.SortedTreeStore.Engine;
using GSF.SortedTreeStore.Engine.Reader;
using NUnit.Framework;
using openHistorian;
using openHistorian.Collections;
using GSF.SortedTreeStore.Tree;

namespace SampleCode.openHistorian.Server.dll
{
    [TestFixture]
    public class Sample2
    {
        [Test]
        public void CreateAllDatabases()
        {
            Array.ForEach(Directory.GetFiles(@"c:\temp\Scada\", "*.d2", SearchOption.AllDirectories), File.Delete);
            Array.ForEach(Directory.GetFiles(@"c:\temp\Synchrophasor\", "*.d2", SearchOption.AllDirectories), File.Delete);

            List<HistorianDatabaseInstance> serverDatabases = new List<HistorianDatabaseInstance>();

            HistorianDatabaseInstance db = new HistorianDatabaseInstance();
            db.DatabaseName = "Scada";
            db.InMemoryArchive = false;
            db.Paths = new[] { @"c:\temp\Scada\" };

            serverDatabases.Add(db);

            db = new HistorianDatabaseInstance();
            db.DatabaseName = "Synchrophasor";
            db.InMemoryArchive = false;
            db.Paths = new[] { @"c:\temp\Synchrophasor\" };

            serverDatabases.Add(db);

            HistorianKey key = new HistorianKey();
            HistorianValue value = new HistorianValue();

            using (HistorianServer server = new HistorianServer(serverDatabases))
            {
                SortedTreeEngineBase<HistorianKey, HistorianValue> database = server["Scada"];

                for (ulong x = 0; x < 10000; x++)
                {
                    key.Timestamp = x;
                    database.Write(key, value);
                }
                database.HardCommit();
                database.Disconnect();

                database = server["Synchrophasor"];
                for (ulong x = 0; x < 10000; x++)
                {
                    key.Timestamp = x;
                    database.Write(key, value);
                }
                database.HardCommit();
                database.Disconnect();
            }
        }

        [Test]
        public void TestReadData()
        {
            List<HistorianDatabaseInstance> serverDatabases = new List<HistorianDatabaseInstance>();

            HistorianDatabaseInstance db = new HistorianDatabaseInstance();
            db.DatabaseName = "Scada";
            db.InMemoryArchive = true;
            db.Paths = new[] { @"c:\temp\Scada\" };

            serverDatabases.Add(db);

            db = new HistorianDatabaseInstance();
            db.DatabaseName = "Synchrophasor";
            db.InMemoryArchive = true;
            db.Paths = new[] { @"c:\temp\Synchrophasor\" };

            serverDatabases.Add(db);

            using (HistorianServer server = new HistorianServer(serverDatabases))
            {
                SortedTreeEngineBase<HistorianKey, HistorianValue> database = server["Scada"];
                using (SortedTreeEngineReaderBase<HistorianKey, HistorianValue> reader = database.OpenDataReader())
                {
                    TreeStream<HistorianKey, HistorianValue> stream = reader.Read(0, 100);
                    stream.Cancel();
                }
                database.Disconnect();

                database = server["Synchrophasor"];
                using (SortedTreeEngineReaderBase<HistorianKey, HistorianValue> reader = database.OpenDataReader())
                {
                    TreeStream<HistorianKey, HistorianValue> stream = reader.Read(0, 100);
                    stream.Cancel();
                }
                database.Disconnect();
            }
        }
    }
}