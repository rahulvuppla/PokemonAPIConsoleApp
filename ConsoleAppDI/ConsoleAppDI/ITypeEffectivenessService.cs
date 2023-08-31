using System.Threading.Tasks;

public interface ITypeEffectivenessService
{
    Task<TypeEffectiveness> GetTypeEffectivenessAsync(string typeUrl);
}
