using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Pets.Common.Enums;

namespace Pets.Repository.Entities
{
    /// <summary>
    /// Pet
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        ///  Name
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Breed
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Breed { get; set; }

        /// <summary>
        ///  Pet Type
        /// </summary>
        [Required]
        public PetTypes Type { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [Required]
        public PetSizes Size { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [Required]
        public PetGenders Gender { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Required]
        [DefaultValue(PetStatuses.Available)]
        public PetStatuses Status { get; set; }
    }
}
