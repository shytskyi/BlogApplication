using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace BlogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IService<Tag> _service;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IService<Tag> service, IMapper mapper)
        {
            _tagService = tagService;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/tag")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Tag>))]
        public IActionResult GetTags()
        {
            var tags = _mapper.Map<List<TagDTO>>(_service.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(tags);
        }

        [HttpGet("/tag/{tag_id}")]
        [ProducesResponseType(200, Type = typeof(Tag))]
        [ProducesResponseType(400)]
        public IActionResult GetTagById(int id)
        {
            if (!_service.Exists(id))
                return NotFound();

            var tag = _mapper.Map<TagDTO>(_service.GetById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tag);
        }

        [HttpGet("blog_by_tag/{tag}")]
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogByTag([FromBody] string tag)
        {
            if (tag == null)
                return BadRequest(ModelState);

            var blog = _mapper.Map<BlogDTO>(_tagService.GetBlogByTag(tag));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(blog);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTag([FromBody] TagDTO tag)
        {
            if (tag == null)
                return BadRequest(ModelState);
            var tagExists = _service.GetAll().Result
                .Where(a => a.TagName.Trim().ToUpper() == tag.TagName.TrimEnd().ToUpper())
                .FirstOrDefault();
            if (tagExists != null)
            {
                ModelState.AddModelError("", "Author already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var tagMap = _mapper.Map<Tag>(tag);
            if (!_service.Create(tagMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully");
        }
    }
}
