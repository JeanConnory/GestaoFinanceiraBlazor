﻿using Gestao.Data;
using Gestao.Domain;
using Gestao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _db;

        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Document?> Get(int id)
        {
            return await _db.Documents.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task Add(Document entity)
        {
            _db.Documents.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Document entity)
        {
            _db.Documents.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);

            if (entity is not null)
            {
                _db.Documents.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
