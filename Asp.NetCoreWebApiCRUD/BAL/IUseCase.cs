
namespace BAL
{
    public interface IUseCase<in TRequest>
    {
        void Execute(TRequest request);
    }
}
