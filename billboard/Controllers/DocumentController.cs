using billboard.Model;
using billboard.services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

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
        public Task<IEnumerable<Model.Document>> GetAllDocumentsAsync()
        {
            return documentService.GetAllDocumentsAsync();
        }
        [HttpGet("{id}", Name = "GetDocumentById")]
        public async Task<ActionResult<Model.Document>> GetDocumentByIdAsync(int id)
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
        public async Task CreateDocumentAsync(Model.Document document)
        {
            await documentService.CreateDocumentAsync(document);
        }

        [HttpPut("{id}", Name = "UpdateDocument")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] Model.Document document)
        {
            if(id != document.DocumentId)
                return BadRequest();
      
            await documentService.UpdateDocumentAsync(document);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDocument")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            // Current document by Id
            var existingDocument = await GetDocumentByIdAsync(id);
            if (existingDocument == null)
                return NotFound();

            await documentService.DeleteDocumentAsync(id);

            return NoContent();
        }
    }
}
