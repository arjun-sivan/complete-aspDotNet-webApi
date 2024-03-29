using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Models;
using MyBooks.Service;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _publisherService;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(PublisherService publisherService, ILogger<PublishersController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllpublishers(string sortBy, string searchString, int pageNumber)
        {
          

            throw new Exception("this is an Exception from GetAllPublishers");

            try
            {
                _logger.LogInformation("this is  just a log in GetAllPublishers");
                var result = _publisherService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(result);

            }
            catch (Exception)
            {

                return BadRequest("Sorry, We could not load the publishers");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddBook([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }


        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
