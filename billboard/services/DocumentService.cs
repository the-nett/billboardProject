using billboard.Model;
using billboard.Repositories;
using System;

namespace billboard.services
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task CreateDocumentAsync(Document document);
        Task UpdateDocumentAsync(Document document);
        Task DeleteDocumentAsync(int id);
    }
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task CreateDocumentAsync(Document document)
        {
            await _documentRepository.CreateDocumentAsync(document);
        }

        public Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return _documentRepository.GetAllDocumentsAsync();
        }

        public Task<Document> GetDocumentByIdAsync(int id)
        {
            return _documentRepository.GetDocumentByIdAsync(id);
        }

        public async Task UpdateDocumentAsync(Document document)
        {
            await _documentRepository.UpdateDocumentAsync(document);   
        }
        public async Task DeleteDocumentAsync(int id)
        {
            await _documentRepository.DeleteDocumentAsync(id);
        }
    }

}
