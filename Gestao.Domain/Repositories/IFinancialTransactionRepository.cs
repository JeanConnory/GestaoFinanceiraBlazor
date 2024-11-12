using Gestao.Domain.Enums;
using Gestao.Domain.Libraries.Utilities;

namespace Gestao.Domain.Repositories
{
    public interface IFinancialTransactionRepository
    {
        Task Add(FinancialTransaction company);
        Task Delete(int id);
        Task<FinancialTransaction> Get(int id);
        Task<PaginatedList<FinancialTransaction>> GetAll(int companyId, TypeFinancialTransaction type, int pageIndex, int pageSize, string searchWord);
        Task Update(FinancialTransaction entity);
    }
}