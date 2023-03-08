using System;
using System.Collections.Generic;

namespace Scaffold.Models
{
    /// <summary>
    /// Defines the types of digital asset locations supported by the system.
    /// </summary>
    public partial class DigitalAssetType
    {
        public DigitalAssetType()
        {
            DigitalAssets = new HashSet<DigitalAsset>();
        }

        /// <summary>
        /// Identifier of the Digital Asset Type record.
        /// </summary>
        public int DigitalAssetTypeId { get; set; }
        /// <summary>
        /// The name of the Digital Asset Type.
        /// </summary>
        public string DigitalAssetTypeName { get; set; } = null!;
        /// <summary>
        /// The discriminator used when saving the different digital asset types.
        /// </summary>
        public string Discriminator { get; set; } = null!;
        /// <summary>
        /// Sorting order of the Digital Asset Type.
        /// </summary>
        public int SortOrder { get; set; }
        /// <summary>
        /// Identifier of the record status (i.e. enabled, disabled, deleted, etc.).
        /// </summary>
        public int RowStatusId { get; set; }

        public virtual ICollection<DigitalAsset> DigitalAssets { get; set; }
    }
}
