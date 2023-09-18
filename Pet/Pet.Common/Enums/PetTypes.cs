using System.ComponentModel;

namespace Pets.Common.Enums
{
    /// <summary>
    /// Pet Types
    /// </summary>
    public enum PetTypes
    {
        /// <summary>
        /// Dogs
        /// </summary>
        [Description("Perro")]
        Dog = 1,

        /// <summary>
        /// Cats
        /// </summary>
        [Description("Gato")]
        Cat = 2,

        /// <summary>
        /// Birds
        /// </summary>
        [Description("Pájaro")]
        Bird = 3,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Otro")]
        Other = 4
    }
}
