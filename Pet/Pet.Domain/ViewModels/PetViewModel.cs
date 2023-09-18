using EnumsNET;

using Pets.Common.Enums;

namespace Pets.Domain.ViewModels
{
    /// <summary>
    /// Pet View Model
    /// </summary>
    public class PetViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///  Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Breed
        /// </summary>
        public string Breed { get; set; }

        /// <summary>
        ///  Pet Type
        /// </summary>
        public PetTypes Type { get; set; }

        /// <summary>
        /// Type Description
        /// </summary>
        public string TypeDescription => Type.AsString(EnumFormat.Description);

        /// <summary>
        /// Size
        /// </summary>
        public PetSizes Size { get; set; }

        /// <summary>
        /// Size Description
        /// </summary>
        public string SizeDescription => Size.AsString(EnumFormat.Description);

        /// <summary>
        /// Gender
        /// </summary>
        public PetGenders Gender { get; set; }

        /// <summary>
        /// Gender Description
        /// </summary>
        public string GenderDescription => Gender.AsString(EnumFormat.Description);

        /// <summary>
        /// Status
        /// </summary>
        public PetStatuses Status { get; set; }

        /// <summary>
        /// Status Description
        /// </summary>
        public string StatusDescription => Status.AsString(EnumFormat.Description);
    }
}
