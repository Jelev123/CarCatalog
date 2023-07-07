using CarCatalog.Core.Constants.Image;
using CarCatalog.Core.Contracts;
using CarCatalog.Core.Contracts.BodyType;
using CarCatalog.Core.Contracts.Car;
using CarCatalog.Core.Contracts.Transmision;
using CarCatalog.Core.Services.Image;
using CarCatalog.Core.ViewModels.BodyType;
using CarCatalog.Core.ViewModels.Car;
using CarCatalog.Core.ViewModels.Transmision;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CarCatalog.Api.Controllers.Car
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService carService;
        private readonly ITransmisionService transmisionService;
        private readonly IBodyTypeService bodyTypeService;
        private readonly IImageService imageService;

        public CarController(ICarService carService, IBodyTypeService bodyTypeService, ITransmisionService transmisionService, IImageService imageService)
        {
            this.carService = carService;
            this.bodyTypeService = bodyTypeService;
            this.transmisionService = transmisionService;
            this.imageService = imageService;
        }

        [Route("GetAllCars")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AllCars(int id = 1)
        {
            const int ItemsPerPage = 1;

            try
            {
                return Ok(carService.GetAll(id, ItemsPerPage));
            }
            catch (ArgumentException ae)
            {

                return BadRequest(ae.Message);
            }
        }

        [HttpGet]
        [Route("GetTransmisionsAndBodyTypes")]
        public IActionResult GetTransmisionsAndBodyTypes()
        {
            var transmisions = transmisionService.AllTransmisions<TransmisionViewModel>();
            var bodyTypes = bodyTypeService.AllBodyTypes<BodyTypeViewModel>();

            var result = new
            {
                Transmisions = transmisions.Select(s => new
                {
                    s.TransmisionType,
                    s.Gears
                }),
                BodyTypes = bodyTypes.Select(s => new
                {
                    s.BodyTypeName,
                    s.Doors
                })
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar([FromForm] CarViewModel addCar, IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    imageService.CheckGallery(addCar);
                }

                carService.AddCars(addCar);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the car.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                var car = carService.GetById(id);
                if (car == null)
                {
                    return NotFound();
                }

                return Ok(car);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred");
            }

        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit([FromForm] CarViewModel car, int id)
        {
            try
            {
                carService.EditCar(car, id);
                return Ok();
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while editing the car.");
            }

        }


        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                carService.DeleteCar(id);
                return Ok();
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the car.");
            }
        }
    }
}
