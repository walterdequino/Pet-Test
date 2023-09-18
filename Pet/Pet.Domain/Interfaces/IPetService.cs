using Pets.Domain.ViewModels;

namespace Pets.Domain.Interfaces
{
    /// <summary>
    /// Interface of PetService
    /// </summary>
    public interface IPetService
    {
        /// <summary>
        /// Get all Pets
        /// </summary>
        /// <returns></returns>
        public Task<IList<PetViewModel>> GetAll();

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PetViewModel> GetById(Guid id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public Task Create(PetViewModel pet);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        public Task Update(PetViewModel pet);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(Guid id);
    }
}
