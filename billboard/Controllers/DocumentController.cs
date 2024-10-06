using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;

namespace billboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService documentService;
        public DocumentController(IDocumentService _documentService)
        {
            documentService = _documentService;
        }
        [HttpGet(Name = "GetAllDocuments")]
        public Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return documentService.GetAllDocumentsAsync();
        }
        [HttpGet("{id}", Name = "GetDocumentById")]
        public async Task<ActionResult<User>> GetDocumentByIdAsync(int id)
        {
            var document = await documentService.GetDocumentByIdAsync(id);
            if (document == null)
                return NotFound();

            return Ok(document);
        }

        [HttpPost(Name = "CreateDocument")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task CreateDocumentAsync(Document document)
        {
            await documentService.CreateDocumentAsync(document);
        }



    }
}
