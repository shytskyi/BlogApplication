using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Interfaces;
using System.Reflection.Metadata;

namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogService<Blog> _blogService;
        private readonly IService<Blog> _service;
        private readonly IMapper _mapper;

        public BlogController(IBlogService<Blog> blogService , IService<Blog> service, IMapper mapper)
        {
            _blogService = blogService;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/blog")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Blog>))]
        public IActionResult GetBlogs() 
        { 
            var blogs = _mapper.Map<List<BlogDTO>>(_service.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(blogs);
        }

        [HttpGet("/blog/{blog_id}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogById(int id) 
        {
            if(!_service.Exists(id))
                return NotFound();

            var blog = _mapper.Map<BlogDTO>(_service.GetById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(blog);
        }

        [HttpGet("{blog_id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogRating (int id) 
        {
            if (!_service.Exists(id))
                return NotFound();

            var rating = _blogService.GetBlogRating(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] BlogDTO blog)
        {
            if (blog == null)
                return BadRequest(ModelState);
            var blogExists = _service.GetAll().Result
                .Where(a => a.Title.Trim().ToUpper() == blog.Title.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (blogExists != null)
            {
                ModelState.AddModelError("", "Author already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var blogMap = _mapper.Map<Blog>(blog);
            if (!_service.Create(blogMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully");
        }
    }
}
