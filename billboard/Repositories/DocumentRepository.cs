using billboard.Context;
using billboard.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace billboard.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task CreateDocumentAsync(Document document);
        Task UpdateDocumentAsync(Document document);
 
    }

    public class DocumentRepository : IDocumentRepository
    {
        private readonly BilllboardDBContext _contextDocument;
        public DocumentRepository(BilllboardDBContext contextDocument)
        {
            _contextDocument = contextDocument;
        }

        public async Task CreateDocumentAsync(Document document)
        {
            // Agregar el nuevo documento a la base de datos
            await _contextDocument.Documents.AddAsync(document);

            // Guardar los cambios
            await _contextDocument.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _contextDocument.Documents.ToListAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _contextDocument.Documents.FindAsync(id);
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            // Current document by Id
            var existingDocument = await GetDocumentByIdAsync(document.DocumentId);

            if (existingDocument != null)
            {
                //Update current document
                existingDocument.DocumentName = document.DocumentName;
                

                // Marcar el documento como modificado para que Entity Framework lo rastree
                //_contextDocument.Entry(existingDocument).State = EntityState.Modified;
                // Save document
                await _contextDocument.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Documento no encontrado");
            }
        }


    }
}
