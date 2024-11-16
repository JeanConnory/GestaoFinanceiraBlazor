using Coravel.Invocable;
using Gestao.Domain;
using Gestao.Domain.Enums;
using Gestao.Domain.Repositories;

namespace Gestao.Libraries.Queues;

public class FinancialTransactionRepeatInvocable : IInvocable, IInvocableWithPayload<FinancialTransaction>
{
    private IFinancialTransactionRepository _repository;

    public FinancialTransaction Payload { get; set; }

    public FinancialTransactionRepeatInvocable(IFinancialTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task Invoke()
    {
        int startPoint = 1;
        int countTransactionsSameGroup = await _repository.GetCountTransacationsSameGroup(Payload.Id);

        //TODO - Queue -> Criar Grupo (Id = Id da primeira parcela)
        await AssignRepeatGroupToPayload();

        //TODO - Cadastrar -> Novas Transações
        //TODO - Editando -> 0 Parcelas -> 10 parcelas -> Novas transações
        if (countTransactionsSameGroup == 0)
        {
            await RegisterNewTransactions(startPoint);
        }
        else
        {
            //TODO - Editando -> 5 parc -> 10 parc -> Novas Transações (6-10)        
            await RegisterNewTransactions(countTransactionsSameGroup);
        }

        //TODO - Editando -> 10 parc -> 7 parc -> Excluir (10-8)
        await TransactionReduction(countTransactionsSameGroup);

        //TODO - Editando -> 10 parc -> 0 parc -> Excluir (2-10) -> Repeat None deixando só a parc 1
        await RepeatTransactionsRemove(countTransactionsSameGroup);
    }

    private async Task AssignRepeatGroupToPayload()
    {
        if (Payload.Repeat != Recurrence.None)
        {
            Payload.RepeatGroup = Payload.Id;
            await _repository.Update(Payload);
        }
    }

    private async Task RepeatTransactionsRemove(int countTransactionsSameGroup)
    {
        if (Payload.Repeat == Recurrence.None && countTransactionsSameGroup > 1)
        {
            var transactions = await _repository.GetTransacationsSameGroup(Payload.Id);
            for (int i = 2; i <= countTransactionsSameGroup; i++)
            {
                await _repository.Delete(transactions.ElementAt(i-1));
            }
        }
    }

    private async Task TransactionReduction(int countTransactionsSameGroup)
    {
        if (Payload.Repeat != Recurrence.None && countTransactionsSameGroup > Payload.RepeatTimes)
        {
            var transactions = await _repository.GetTransacationsSameGroup(Payload.Id);
            for (int i = countTransactionsSameGroup; i > Payload.RepeatTimes; i--)
            {
                await _repository.Delete(transactions.ElementAt(i-1));
            }
        }
    }

    private async Task RegisterNewTransactions(int startPoint)
    {
        if (Payload.Repeat != Recurrence.None)
        {
            var repeatTimes = Payload.RepeatTimes - 1;

            for (int i = startPoint; i <= repeatTimes; i++)
            {
                var financial = new FinancialTransaction();
                financial.TypeFinancialTransaction = Payload.TypeFinancialTransaction;
                financial.Description = Payload.Description;
                financial.ReferenceDate = IncrementDate(Payload.Repeat, i, Payload.ReferenceDate);
                financial.DueDate = Payload.DueDate.HasValue ? IncrementDate(Payload.Repeat, i, Payload.DueDate.Value) : null;
                financial.Amount = Payload.Amount;
                financial.RepeatGroup = Payload.Id;
                financial.Repeat = Recurrence.None;
                financial.RepeatTimes = null;
                financial.CreatedAt = DateTimeOffset.Now;

                financial.CompanyId = Payload.CompanyId;
                financial.AccountId = Payload.AccountId;
                financial.CategoryId = Payload.CategoryId;

                await _repository.Add(financial);
            }
        }
    }

    private DateTimeOffset IncrementDate(Recurrence repeat, int count, DateTimeOffset date)
    {
        DateTimeOffset dateModified = date;
        switch (repeat)
        {
            case Recurrence.Weekly:
                dateModified = date.AddDays(7 * count);
                break;
            case Recurrence.Monthly:
                dateModified = date.AddMonths(count);
                break;
            case Recurrence.Yearly:
                dateModified = date.AddYears(count);
                break;
            default:
                break;
        }
        return dateModified;
    }
}
