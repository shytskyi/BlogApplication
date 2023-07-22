using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Interfaces;

namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IService<Author> _service;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IService<Author> service, IMapper mapper)
        {
            _authorService = authorService;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/author")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {

            var authors = _mapper.Map<List<AuthorDTO>>(_service.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(authors);
        }

        [HttpGet("/author/{author_id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorById(int id)
        {
            if (!_service.Exists(id))
                return NotFound();

            var author = _mapper.Map<AuthorDTO>(_service.GetById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(author);
        }

        [HttpGet("/blog_by_tagname/{tagname}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogByAuthorName([FromBody] string name)
        {
            if (name == null)
                return BadRequest(ModelState);
            var blog = _mapper.Map<BlogDTO>(_authorService.GetBlogByAuthorName(name));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(blog);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] AuthorDTO author)
        {
            if (author == null)
                return BadRequest(ModelState);
            var authorExists = _service.GetAll().Result
                .Where(a => (a.FirstName + " " + a.LastName) == (author.FirstName + " " + author.LastName))
                .FirstOrDefault();
            if(authorExists != null)
            {
                ModelState.AddModelError("", "Author already exists");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorMap = _mapper.Map<Author>(author);
            if (!_service.Create(authorMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully");
        }
    }
}
