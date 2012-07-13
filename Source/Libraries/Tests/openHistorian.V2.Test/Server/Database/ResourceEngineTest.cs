﻿using openHistorian.V2.Server.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace openHistorian.V2.Test
{


    /// <summary>
    ///This is a test class for ResourceEngineTest and is intended
    ///to contain all ResourceEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResourceEngineTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ResourceEngine Constructor
        ///</summary>
        [TestMethod()]
        public void ResourceEngineConstructorTest()
        {
            ResourceEngine target = new ResourceEngine(GetSettings());
        }

        ResourceEngineSettings GetSettings()
        {
            ResourceEngineSettings settings = new ResourceEngineSettings();
            var part = new PartitionInitializerGenerationSettings();
            part.IsMemoryPartition = true;
            settings.PartitionInitializerSettings.GenerationSettings.Add(part); //Gen 0
            settings.PartitionInitializerSettings.GenerationSettings.Add(part); //Gen 1
            settings.PartitionInitializerSettings.GenerationSettings.Add(part); //Gen 2
            settings.PartitionInitializerSettings.GenerationSettings.Add(part); //Gen 3
            return settings;
        }

        /// <summary>
        ///A test for AquireSnapshot
        ///</summary>
        [TestMethod()]
        public void AquireSnapshotTest()
        {
            ResourceEngineSettings settings = null; // TODO: Initialize to an appropriate value
            ResourceEngine target = new ResourceEngine(settings); // TODO: Initialize to an appropriate value
            TransactionResources transaction = null; // TODO: Initialize to an appropriate value
            //target.AquireSnapshot(transaction);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateNewClientResources
        ///</summary>
        [TestMethod()]
        public void CreateNewClientResourcesTest()
        {
            ResourceEngine target = new ResourceEngine(GetSettings()); // TODO: Initialize to an appropriate value
            var actual = target.CreateNewClientResources();
            //target.AquireSnapshot(actual);
        }

        /// <summary>
        ///A test for ReleaseClientResources
        ///</summary>
        [TestMethod()]
        public void ReleaseClientResourcesTest()
        {
            ResourceEngineSettings settings = null; // TODO: Initialize to an appropriate value
            ResourceEngine target = new ResourceEngine(settings); // TODO: Initialize to an appropriate value
            TransactionResources resources = null; // TODO: Initialize to an appropriate value
            //target.ReleaseClientResources(resources);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for StartPartitionInsertMode
        ///</summary>
        [TestMethod()]
        public void StartPartitionInsertModeTest()
        {
            ResourceEngineSettings settings = null; // TODO: Initialize to an appropriate value
            ResourceEngine target = new ResourceEngine(settings); // TODO: Initialize to an appropriate value
            int generation = 0; // TODO: Initialize to an appropriate value
            ResourceEngine.PartitionInsertMode expected = null; // TODO: Initialize to an appropriate value
            ResourceEngine.PartitionInsertMode actual;
            actual = target.StartPartitionInsertMode(generation);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StartPartitionRolloverMode
        ///</summary>
        [TestMethod()]
        public void StartPartitionRolloverModeTest()
        {
            ResourceEngineSettings settings = null; // TODO: Initialize to an appropriate value
            ResourceEngine target = new ResourceEngine(settings); // TODO: Initialize to an appropriate value
            int generation = 0; // TODO: Initialize to an appropriate value
            ResourceEngine.PartitionRolloverMode expected = null; // TODO: Initialize to an appropriate value
            ResourceEngine.PartitionRolloverMode actual;
            actual = target.StartPartitionRolloverMode(generation);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
