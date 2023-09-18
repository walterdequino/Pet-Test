using System.ComponentModel;

namespace Pets.Common.Enums
{
    /// <summary>
    /// Statuses
    /// </summary>
    public enum PetStatuses
    {
        /// <summary>
        /// Available
        /// </summary>
        [Description("Disponible")]
        Available = 1,

        /// <summary>
        /// Male
        /// </summary>
        [Description("Adoptado")]
        Adopted = 2,

        /// <summary>
        /// Lost
        /// </summary>
        [Description("Perdido")]
        Lost = 3
    }
}
