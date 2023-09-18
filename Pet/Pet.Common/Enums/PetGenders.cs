using System.ComponentModel;

namespace Pets.Common.Enums
{
    /// <summary>
    /// Genders
    /// </summary>
    public enum PetGenders
    {
        /// <summary>
        /// Male
        /// </summary>
        [Description("Macho")]
        Male = 1,

        /// <summary>
        /// Female
        /// </summary>
        [Description("Hembra")]
        Female = 2
    }
}
