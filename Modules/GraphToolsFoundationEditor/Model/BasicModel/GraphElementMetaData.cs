// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine;

namespace Unity.GraphToolsFoundation.Editor
{
    [Serializable]
    class GraphElementMetaData
    {
        [SerializeField]
        SerializableGUID m_Guid;

        [SerializeField]
        ManagedMissingTypeModelCategory m_Category;

        [SerializeField]
        int m_Index;

        /// <summary>
        /// Whether the graph element object should be removed.
        /// </summary>
        /// <remarks>
        /// This is used to properly remove null objects with a missing type.
        /// When the user deletes a placeholder, it is not possible to remove the associated null object right away because of the way serialization works.
        /// The object will be removed on the next loading of the graph.
        /// </remarks>
        public bool ToRemove { get; set; }

        /// <summary>
        /// The GUID of the graph element.
        /// </summary>
        public SerializableGUID Guid
        {
            get => m_Guid;
            set => m_Guid = value;
        }

        /// <summary>
        /// The category of the graph element.
        /// </summary>
        public ManagedMissingTypeModelCategory Category
        {
            get => m_Category;
            set => m_Category = value;
        }

        /// <summary>
        /// The index of the graph element in the graph's corresponding list.
        /// </summary>
        public int Index
        {
            get => m_Index;
            set => m_Index = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphElementMetaData"/> class.
        /// </summary>
        public GraphElementMetaData(Model model, int index)
        {
            Guid = model.Guid;
            Index = index;
            Category = PlaceholderModelHelper.ModelToMissingTypeCategory_Internal(model);
        }
    }
}
