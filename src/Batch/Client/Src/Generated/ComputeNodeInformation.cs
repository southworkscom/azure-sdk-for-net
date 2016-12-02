// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

//
// This file was autogenerated by a tool.
// Do not modify it.
//

namespace Microsoft.Azure.Batch
{
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The compute node information class.
    /// </summary>
    public partial class ComputeNodeInformation : IPropertyMetadata
    {
        private readonly string affinityId;
        private readonly string computeNodeId;
        private readonly string computeNodeUrl;
        private readonly string poolId;
        private readonly string taskRootDirectory;
        private readonly string taskRootDirectoryUrl;

        #region Constructors

        internal ComputeNodeInformation(Models.ComputeNodeInformation protocolObject)
        {
            this.affinityId = protocolObject.AffinityId;
            this.computeNodeId = protocolObject.NodeId;
            this.computeNodeUrl = protocolObject.NodeUrl;
            this.poolId = protocolObject.PoolId;
            this.taskRootDirectory = protocolObject.TaskRootDirectory;
            this.taskRootDirectoryUrl = protocolObject.TaskRootDirectoryUrl;
        }

        #endregion Constructors

        #region ComputeNodeInformation

        /// <summary>
        /// Gets an opaque string that contains information about the location of the compute node.
        /// </summary>
        public string AffinityId
        {
            get { return this.affinityId; }
        }

        /// <summary>
        /// Gets the compute node id.
        /// </summary>
        public string ComputeNodeId
        {
            get { return this.computeNodeId; }
        }

        /// <summary>
        /// Gets the URL of the compute node.
        /// </summary>
        public string ComputeNodeUrl
        {
            get { return this.computeNodeUrl; }
        }

        /// <summary>
        /// Gets the pool id.
        /// </summary>
        public string PoolId
        {
            get { return this.poolId; }
        }

        /// <summary>
        /// Gets the root directory of the current task on the compute node. You can use this path to retrieve files created 
        /// by the task such as log files.
        /// </summary>
        public string TaskRootDirectory
        {
            get { return this.taskRootDirectory; }
        }

        /// <summary>
        /// Gets the URL to the root directory of the current task on the compute node.
        /// </summary>
        public string TaskRootDirectoryUrl
        {
            get { return this.taskRootDirectoryUrl; }
        }

        #endregion // ComputeNodeInformation

        #region IPropertyMetadata

        bool IModifiable.HasBeenModified
        {
            //This class is compile time readonly so it cannot have been modified
            get { return false; }
        }

        bool IReadOnly.IsReadOnly
        {
            get { return true; }
            set
            {
                // This class is compile time readonly already
            }
        }

        #endregion // IPropertyMetadata
    }
}