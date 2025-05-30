namespace TezMektepKz.Services.Interfaces
{
    public interface IIndividualNumberService
    {
        public Task<bool> IsValid(string individualNumber);
        public Task<DateOnly?> GetBornDateFromIndividualNumber(string individualNumber);
    }
}
