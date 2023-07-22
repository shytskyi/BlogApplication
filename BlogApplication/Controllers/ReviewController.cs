using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Interfaces;

namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IService<Review> _service;
        private readonly IMapper _mapper;

        public ReviewController(IService<Review> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/review")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var blogs = _mapper.Map<List<ReviewDTO>>(_service.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(blogs);
        }

        [HttpGet("/review/{review_id}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewById(int id)
        {
            if (!_service.Exists(id))
                return NotFound();

            var blog = _mapper.Map<ReviewDTO>(_service.GetById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(blog);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] ReviewDTO review)
        {
            if (review == null)
                return BadRequest(ModelState);
       
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reviewMap = _mapper.Map<Review>(review);
            if (!_service.Create(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully");
        }
    }
}
