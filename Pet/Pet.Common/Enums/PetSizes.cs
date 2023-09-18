using System.ComponentModel;

namespace Pets.Common.Enums
{
    /// <summary>
    /// Pet Sizes
    /// </summary>
    public enum PetSizes
    {
        /// <summary>
        /// Small
        /// </summary>
        [Description("Pequeño")]
        Small = 1,

        /// <summary>
        /// Medium
        /// </summary>
        [Description("Mediano")]
        Medium = 2,

        /// <summary>
        /// Large
        /// </summary>
        [Description("Grande")]
        Large = 3,

        /// <summary>
        /// Extra Large
        /// </summary>
        [Description("Gigante")]
        ExtraLarge = 4
    }
}
