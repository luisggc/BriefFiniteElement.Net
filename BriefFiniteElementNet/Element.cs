﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BriefFiniteElementNet
{
    /// <summary>
    /// Represents an abstract class for a 'Finite Element' with physical properties.
    /// </summary>
    
    public abstract class Element : StructurePart
    {
        protected ElementType elementType;

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public ElementType ElementType
        {
            get { return elementType; }
            private set { elementType = value; }
        }



        protected List<Load> loads = new List<Load>();

        /// <summary>
        /// Gets or sets the loads.
        /// </summary>
        /// <value>
        /// The loads.
        /// </value>
        public List<Load> Loads
        {
            get { return loads; }
        }

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public Node[] Nodes
        {
            get { return nodes; }
            private set { nodes = value; }
        }

        protected Node[] nodes;

        internal int[] nodeNumbers;

        /// <summary>
        /// Gets the stifness matrix of member in global coordination system.
        /// </summary>
        /// <returns>The stiffnes matrix</returns>
        /// <remarks>
        /// The number of DoFs is in element local regrading order in <see cref="Nodes"/>!</remarks>
        public abstract Matrix GetGlobalStifnessMatrix();

        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="nodes">The number of nodes that the <see cref="Element"/> connect together.</param>
        protected Element(int nodes)
        {
            this.nodes = new Node[nodes];
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        protected Element()
        {
        }



        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.nodeNumbers = new int[this.nodes.Length];
            for (int i = 0; i < nodes.Length; i++)
                nodeNumbers[i] = nodes[i].Index;

            info.AddValue("elementType", (int)elementType);
            info.AddValue("loads", loads);
            info.AddValue("nodeNumbers", nodeNumbers);

            base.GetObjectData(info, context);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected Element(SerializationInfo info, StreamingContext context):base(info,context)
        {
            nodeNumbers = info.GetValue<int[]>("nodeNumbers");
            elementType = (ElementType)info.GetInt32("elementType");
            loads = info.GetValue<List<Load>>("loads");
            this.nodes=new Node[nodeNumbers.Length];
        }



    }
}