using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Pets.Domain.Interfaces;
using Pets.Domain.ViewModels;
using Pets.Repository;
using Pets.Repository.Entities;

namespace Pets.Domain.Services
{
    /// <summary>
    /// Pet Service
    /// </summary>
    public class PetService : IPetService
    {
        /// <summary>
        /// Db Context
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PetService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IList<PetViewModel>> GetAll()
        {
            return _mapper.Map<IList<Pet>, IList<PetViewModel>>(await _dbContext.Pets.ToListAsync());
        }

        /// <inheritdoc/>
        public async Task<PetViewModel> GetById(Guid id)
        {
            return _mapper.Map<Pet, PetViewModel>(await _dbContext.Pets.FindAsync(id));
        }

        /// <inheritdoc/>
        public async Task Create(PetViewModel pet)
        {
            var petToCreate = _mapper.Map<PetViewModel, Pet>(pet);
            petToCreate.Id = Guid.NewGuid();

            await _dbContext.AddAsync(petToCreate);

            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task Update(PetViewModel pet)
        {
            var actual = await _dbContext.Pets.FindAsync(pet.Id);

            if (actual is null)
            {
                throw new Exception("Not Found Pet");
            }

            actual.Breed = pet.Breed;
            actual.Gender = pet.Gender;
            actual.Name = pet.Name;
            actual.Size = pet.Size;
            actual.Status = pet.Status;
            actual.Type = pet.Type;

            _dbContext.Update(actual);

            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task Delete(Guid id)
        {
            var actual = await _dbContext.Pets.FindAsync(id);

            if (actual is null)
            {
                throw new Exception("Not Found Pet");
            }

            _dbContext.Remove(actual);

            await _dbContext.SaveChangesAsync();
        }
    }
}
