using Microsoft.AspNetCore.Mvc;

using Pets.Domain.Interfaces;
using Pets.Domain.ViewModels;
using Pets.WebApi.Urls;

namespace Pets.WebApi.Controllers
{
    /// <summary>
    /// Pet Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PetController : ControllerBase
    {
        /// <summary>
        /// Pet Service
        /// </summary>
        private readonly IPetService _petService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="petService"></param>
        public PetController(IPetService petService) { _petService = petService; }

        /// <summary>
        /// Get All Pets
        /// </summary>
        /// <returns>
        /// The List of <see cref="PetViewModel"/>.
        /// </returns>
        [HttpGet(PetControllerUrls.GetAll)]
        [ProducesResponseType(typeof(List<PetViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() { return Ok(await _petService.GetAll()); }

        /// <summary>
        /// Get Pet By Id
        /// </summary>
        /// <param name="id">
        /// Id of the Pet
        /// </param>
        /// <returns>
        /// The <see cref="PetViewModel"/>.
        /// </returns>
        [HttpGet(PetControllerUrls.GetById)]
        [ProducesResponseType(typeof(PetViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id.");
            }

            var pet = await _petService.GetById(id);

            if (pet is null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        /// <summary>
        /// Create Pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost(PetControllerUrls.Create)]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(PetViewModel pet)
        {
            await _petService.Create(pet);

            return Ok();
        }

        /// <summary>
        /// Create Pet
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPut(PetControllerUrls.Update)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(PetViewModel pet)
        {
            if (pet.Id == Guid.Empty)
            {
                return BadRequest("Invalid Id.");
            }

            await _petService.Update(pet);

            return NoContent();
        }

        /// <summary>
        /// Delete Pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(PetControllerUrls.Delete)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id.");
            }

            await _petService.Delete(id);

            return NoContent();
        }
    }
}
